using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MQTTConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting Subsriber....");

                //create subscriber client
                var factory = new MqttFactory();
                var _client = factory.CreateMqttClient();
                //string payload = @"{'end_device_ids':{'device_id':'soham-demo','application_ids':{'application_id':'watermeter'},'dev_eui':'10000000C9640014','join_eui':'70B3D57ED0016420','dev_addr':'27003A5D'},'correlation_ids':['as:up:01GBFA723DSH7785YCKC8N3NB9','gs:conn:01GBCD30BS87SX95D706N88QEZ','gs:up:host:01GBCD30C40RP8YY5EHV64Q956','gs:uplink:01GBFA71WRRN7P9B080D690J1E','ns:uplink:01GBFA71WRN8BR8ENJ6J2ATV3R','rpc:/ttn.lorawan.v3.GsNs/HandleUplink:01GBFA71WRYPMZDBY2TQ3RXKYK','rpc:/ttn.lorawan.v3.NsAs/HandleUplink:01GBFA72388VV56EK79GA3BDSA'],'received_at':'2022-08-27T09:30:35.501274189Z','uplink_message':{'session_key_id':'AYKXSmqINDT29VSApeSL5A==','f_port':1,'f_cnt':332,'frm_payload':'MTFfMTFfMTFfMTFfMTFfMTFfMA==','rx_metadata':[{'gateway_ids':{'gateway_id':'sisoc','eui':'A840411D1F004150'},'time':'2022-08-27T09:30:35.211245Z','timestamp':2076683660,'rssi':-69,'channel_rssi':-69,'snr':9.5,'uplink_token':'ChMKEQoFc2lzb2MSCKhAQR0fAEFQEIzbnt4HGgwIu8inmAYQpbiriQEg4NX3n7j3FioLCLvIp5gGEMiv3WQ=','channel_index':6,'received_at':'2022-08-27T09:30:35.288021541Z'}],'settings':{'data_rate':{'lora':{'bandwidth':125000,'spreading_factor':7}},'coding_rate':'4/5','frequency':'866585000','timestamp':2076683660,'time':'2022-08-27T09:30:35.211245Z'},'received_at':'2022-08-27T09:30:35.288797784Z','confirmed':true,'consumed_airtime':'0.071936s','network_ids':{'net_id':'000013','tenant_id':'cybereye','cluster_id':'eu1','cluster_address':'eu1.cloud.thethings.industries','tenant_address':'cybereye.eu1.cloud.thethings.industries'}}}";
                string message = "";

                // var json = JsonConvert.DeserializeObject(payload);



                //configure options
                var _options = new MqttClientOptionsBuilder()
                    .WithClientId("cybereye")
                    .WithTcpServer("eu1.cloud.thethings.industries", 1883)
                    .WithCredentials("watermeter@cybereye", "NNSXS.YIULJYTECKT3YFWAXBLBP5OIIIK2MQZUGB2YH7Y.VGECQDDSXNGBO2V6JFFYPWOTZCEQQ4EDIEB7RP3BIPLGNFW22O3A")
                    .WithCleanSession()
                    .Build();

                //Handlers
                _client.UseConnectedHandler(e =>
                {
                    Console.WriteLine("Connected successfully with MQTT Brokers.");

                    //Subscribe to topic
                    _client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("#").Build()).Wait();
                    //_client.SubscribeAsync();
                });
                //_client.UseDisconnectedHandler(e =>
                //{
                //    Console.WriteLine("Disconnected from MQTT Brokers.");
                //});
                _client.UseApplicationMessageReceivedHandler(e =>
                {

                    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                    var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                    var json = JObject.Parse(payload);
                    end_device_ids endDevice = new end_device_ids();
                    if (json != null)
                    {
                        endDevice.device_id = json["end_device_ids"].ToList()[0].ToList().FirstOrDefault().ToString();
                        endDevice.dev_eui = json["end_device_ids"].ToList()[2].ToList().FirstOrDefault().ToString();
                        endDevice.application_id = json["end_device_ids"].ToList()[1].ToList()[0].ToList().FirstOrDefault().First.ToString();
                        endDevice.payload = json["uplink_message"].ToList()[3].ToList().FirstOrDefault().ToString();
                        var parseJson = JObject.Parse(json["uplink_message"].ToList()[4].ToList()[0].First().ToString());
                        //var deviceName = deviceDetails[0].ToList().FirstOrDefault().ToString();
                        //endDevice.time = Convert.ToDateTime(parseJson["time"].ToString());
                        endDevice.time = Convert.ToDateTime(json["uplink_message"].ToList()[6].First.ToString());
                        var base64EncodedBytes = System.Convert.FromBase64String(endDevice.payload);
                        endDevice.payloadASCII = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    }

                    HydroidEntities db = new HydroidEntities();
                    var mstDevices = db.Mst_Device.ToList();

                    if (endDevice != null)
                    {
                        var flag = (mstDevices.FindAll(n => n.Device_Id == endDevice.device_id).Count > 0 ? true : false);
                        if (flag)
                        {
                            Sync_datum sync = new Sync_datum();
                            sync.Status = true;
                            sync.Device_Id = endDevice.device_id;
                            sync.Created_Date = DateTime.Now;
                            sync.Created_By = "Service";
                            sync.Modified_By = "Service";
                            sync.Modified_Date = DateTime.Now;
                            sync.Application_Id = endDevice.application_id;
                            sync.PayLoad_ASCII = endDevice.payloadASCII;
                            sync.PayLoad_Base64 = endDevice.payload;
                            sync.Serial = endDevice.dev_eui;
                            sync.Time = endDevice.time.GetValueOrDefault();

                            db.Sync_datum.Add(sync);
                            db.SaveChanges();
                        }
                    }




                });

                //actually connect
                _client.ConnectAsync(_options).Wait();


                //To keep the app running in container
                //https://stackoverflow.com/questions/38549006/docker-container-exits-immediately-even-with-console-readline-in-a-net-core-c
                Task.Run(() => Thread.Sleep(Timeout.Infinite)).Wait();
                _client.DisconnectAsync().Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public class end_device_ids
        {
            public string device_id { get; set; }
            public List<application_ids> application_ids { get; set; }
            public string dev_eui { get; set; }
            public string join_eui { get; set; }
            public string dev_addr { get; set; }
            public string application_id { get; set; }
            public string payload { get; set; }
            public DateTime? time { get; set; }
            public string payloadASCII { get; set; }

        }

        public class application_ids
        {
            public string application_id { get; set; }
        }
    }
}