
using System;

namespace BlazorManageLettings.Dto
{
    public class ReturnHouseWithLandlordDto
    {
        public int Id { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }

        public string Tenant1 { get; set; }
        public string Tenant2 { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int LandlordId { get; set; }
        public decimal Rent { get; set; }
        public decimal Deposit { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public LandlordDto Landlord { get; set; }
    }
}
