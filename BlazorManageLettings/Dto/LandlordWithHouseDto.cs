using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorManageLettings.Dto
{
    public class LandlordWithHouseDto
    {
      
        public int Id { get; set; }
        [Required, DisplayName("Landlord Name")]
        public string Name { get; set; }

        [Required, DisplayName("Address")]
        public string Address1 { get; set; }

        [Required, DisplayName("Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        public ReturnHousesDto[] Houses { get; set; } = new ReturnHousesDto[] { };
    }
}
