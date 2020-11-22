using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Dto
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
        public List<ReturnHousesDto> Houses { get; set; } = new List<ReturnHousesDto>();
    }
}
