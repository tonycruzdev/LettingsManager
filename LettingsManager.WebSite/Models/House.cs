using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LettingsManager.WebSite.Models
{
    public class House 
    {
        public int Id { get; set; }
        [Required, DisplayName("Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        [Required, DisplayName("Tenant")]
        public string Tenant1 { get; set; }
        [DisplayName("Tenant")]
        public string Tenant2 { get; set; }
        [Required, DisplayName("Contract Start")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }
        [Required, DisplayName("End of Contract")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        public int LandlordId { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Rent { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Deposit { get; set; }
        [Required,DisplayName("Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        public Landlord Landlord { get; set; }

    }
    public class HouseInfo
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
        public string LandlordName { get; set; }
        public decimal Rent { get; set; }
        public decimal Deposit { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}