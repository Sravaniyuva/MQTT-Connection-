﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MQTTConnection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HydroidEntities : DbContext
    {
        public HydroidEntities()
            : base("name=HydroidEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Mst_Device> Mst_Device { get; set; }
        public virtual DbSet<UserDeviceConsumption> UserDeviceConsumptions { get; set; }
        public virtual DbSet<Sync_datum> Sync_datum { get; set; }
    
        public virtual int AddNewDeviceDetails(string selected, string deviceID, string serialID, string type, string network, string pIN, string country, string leakageLimit, string dTT)
        {
            var selectedParameter = selected != null ?
                new ObjectParameter("Selected", selected) :
                new ObjectParameter("Selected", typeof(string));
    
            var deviceIDParameter = deviceID != null ?
                new ObjectParameter("DeviceID", deviceID) :
                new ObjectParameter("DeviceID", typeof(string));
    
            var serialIDParameter = serialID != null ?
                new ObjectParameter("SerialID", serialID) :
                new ObjectParameter("SerialID", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            var networkParameter = network != null ?
                new ObjectParameter("Network", network) :
                new ObjectParameter("Network", typeof(string));
    
            var pINParameter = pIN != null ?
                new ObjectParameter("PIN", pIN) :
                new ObjectParameter("PIN", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var leakageLimitParameter = leakageLimit != null ?
                new ObjectParameter("LeakageLimit", leakageLimit) :
                new ObjectParameter("LeakageLimit", typeof(string));
    
            var dTTParameter = dTT != null ?
                new ObjectParameter("DTT", dTT) :
                new ObjectParameter("DTT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewDeviceDetails", selectedParameter, deviceIDParameter, serialIDParameter, typeParameter, networkParameter, pINParameter, countryParameter, leakageLimitParameter, dTTParameter);
        }
    
        public virtual int AddNewOrgDetails(string org_Select, string org_ID, string org_Name, string org_Type, string org_Address, string org_City, string org_Post, string org_Country, string org_ContactNumber, string org_Website, string apt_Select, string apt_ID, string apt_Name, string selectOrganisation, string bld_Select, string bld_ID, string bld_Name, string selectAptComplex, string floor_Select, string floor_ID, string floor_Name, string floor_SelectOrganisation, string unit_Select, string unit_ID, string unit_Name, string unitDeviceMapping_Select, string selectDevice)
        {
            var org_SelectParameter = org_Select != null ?
                new ObjectParameter("Org_Select", org_Select) :
                new ObjectParameter("Org_Select", typeof(string));
    
            var org_IDParameter = org_ID != null ?
                new ObjectParameter("Org_ID", org_ID) :
                new ObjectParameter("Org_ID", typeof(string));
    
            var org_NameParameter = org_Name != null ?
                new ObjectParameter("Org_Name", org_Name) :
                new ObjectParameter("Org_Name", typeof(string));
    
            var org_TypeParameter = org_Type != null ?
                new ObjectParameter("Org_Type", org_Type) :
                new ObjectParameter("Org_Type", typeof(string));
    
            var org_AddressParameter = org_Address != null ?
                new ObjectParameter("Org_Address", org_Address) :
                new ObjectParameter("Org_Address", typeof(string));
    
            var org_CityParameter = org_City != null ?
                new ObjectParameter("Org_City", org_City) :
                new ObjectParameter("Org_City", typeof(string));
    
            var org_PostParameter = org_Post != null ?
                new ObjectParameter("Org_Post", org_Post) :
                new ObjectParameter("Org_Post", typeof(string));
    
            var org_CountryParameter = org_Country != null ?
                new ObjectParameter("Org_Country", org_Country) :
                new ObjectParameter("Org_Country", typeof(string));
    
            var org_ContactNumberParameter = org_ContactNumber != null ?
                new ObjectParameter("Org_ContactNumber", org_ContactNumber) :
                new ObjectParameter("Org_ContactNumber", typeof(string));
    
            var org_WebsiteParameter = org_Website != null ?
                new ObjectParameter("Org_Website", org_Website) :
                new ObjectParameter("Org_Website", typeof(string));
    
            var apt_SelectParameter = apt_Select != null ?
                new ObjectParameter("Apt_Select", apt_Select) :
                new ObjectParameter("Apt_Select", typeof(string));
    
            var apt_IDParameter = apt_ID != null ?
                new ObjectParameter("Apt_ID", apt_ID) :
                new ObjectParameter("Apt_ID", typeof(string));
    
            var apt_NameParameter = apt_Name != null ?
                new ObjectParameter("Apt_Name", apt_Name) :
                new ObjectParameter("Apt_Name", typeof(string));
    
            var selectOrganisationParameter = selectOrganisation != null ?
                new ObjectParameter("SelectOrganisation", selectOrganisation) :
                new ObjectParameter("SelectOrganisation", typeof(string));
    
            var bld_SelectParameter = bld_Select != null ?
                new ObjectParameter("Bld_Select", bld_Select) :
                new ObjectParameter("Bld_Select", typeof(string));
    
            var bld_IDParameter = bld_ID != null ?
                new ObjectParameter("Bld_ID", bld_ID) :
                new ObjectParameter("Bld_ID", typeof(string));
    
            var bld_NameParameter = bld_Name != null ?
                new ObjectParameter("Bld_Name", bld_Name) :
                new ObjectParameter("Bld_Name", typeof(string));
    
            var selectAptComplexParameter = selectAptComplex != null ?
                new ObjectParameter("SelectAptComplex", selectAptComplex) :
                new ObjectParameter("SelectAptComplex", typeof(string));
    
            var floor_SelectParameter = floor_Select != null ?
                new ObjectParameter("Floor_Select", floor_Select) :
                new ObjectParameter("Floor_Select", typeof(string));
    
            var floor_IDParameter = floor_ID != null ?
                new ObjectParameter("Floor_ID", floor_ID) :
                new ObjectParameter("Floor_ID", typeof(string));
    
            var floor_NameParameter = floor_Name != null ?
                new ObjectParameter("Floor_Name", floor_Name) :
                new ObjectParameter("Floor_Name", typeof(string));
    
            var floor_SelectOrganisationParameter = floor_SelectOrganisation != null ?
                new ObjectParameter("Floor_SelectOrganisation", floor_SelectOrganisation) :
                new ObjectParameter("Floor_SelectOrganisation", typeof(string));
    
            var unit_SelectParameter = unit_Select != null ?
                new ObjectParameter("Unit_Select", unit_Select) :
                new ObjectParameter("Unit_Select", typeof(string));
    
            var unit_IDParameter = unit_ID != null ?
                new ObjectParameter("Unit_ID", unit_ID) :
                new ObjectParameter("Unit_ID", typeof(string));
    
            var unit_NameParameter = unit_Name != null ?
                new ObjectParameter("Unit_Name", unit_Name) :
                new ObjectParameter("Unit_Name", typeof(string));
    
            var unitDeviceMapping_SelectParameter = unitDeviceMapping_Select != null ?
                new ObjectParameter("UnitDeviceMapping_Select", unitDeviceMapping_Select) :
                new ObjectParameter("UnitDeviceMapping_Select", typeof(string));
    
            var selectDeviceParameter = selectDevice != null ?
                new ObjectParameter("SelectDevice", selectDevice) :
                new ObjectParameter("SelectDevice", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewOrgDetails", org_SelectParameter, org_IDParameter, org_NameParameter, org_TypeParameter, org_AddressParameter, org_CityParameter, org_PostParameter, org_CountryParameter, org_ContactNumberParameter, org_WebsiteParameter, apt_SelectParameter, apt_IDParameter, apt_NameParameter, selectOrganisationParameter, bld_SelectParameter, bld_IDParameter, bld_NameParameter, selectAptComplexParameter, floor_SelectParameter, floor_IDParameter, floor_NameParameter, floor_SelectOrganisationParameter, unit_SelectParameter, unit_IDParameter, unit_NameParameter, unitDeviceMapping_SelectParameter, selectDeviceParameter);
        }
    
        public virtual int AddNewUsersDetails(string selected, string iD, string name, string type, string city, string post, string country, string contactNumber, string website)
        {
            var selectedParameter = selected != null ?
                new ObjectParameter("selected", selected) :
                new ObjectParameter("selected", typeof(string));
    
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var postParameter = post != null ?
                new ObjectParameter("post", post) :
                new ObjectParameter("post", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("ContactNumber", contactNumber) :
                new ObjectParameter("ContactNumber", typeof(string));
    
            var websiteParameter = website != null ?
                new ObjectParameter("website", website) :
                new ObjectParameter("website", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewUsersDetails", selectedParameter, iDParameter, nameParameter, typeParameter, cityParameter, postParameter, countryParameter, contactNumberParameter, websiteParameter);
        }
    
        public virtual ObjectResult<getUserData_Result> getUserData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUserData_Result>("getUserData");
        }
    
        public virtual ObjectResult<string> Login(string name, string password)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Login", nameParameter, passwordParameter);
        }
    }
}
