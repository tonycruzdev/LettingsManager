using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Dto
{
    public class HouseEditDto
    {
        public int Id { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string Address3 { get; set; }
        [Required]
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        [Required]
        public string Tenant1 { get; set; }
        public string Tenant2 { get; set; }
        [Required, DisplayName("Contract Start")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }
        [Required, DisplayName("End of Contract")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        [Required, DisplayName("Landlord")]
        public int LandlordId { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Rent { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Deposit { get; set; }
        [Required, DisplayName("Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
