using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Dto
{
    public class LandlordDto
    {
        public int Id { get; set; }
        [Required, DisplayName("Landlord Name")]
        public string Name { get; set; }

        [Required, DisplayName("Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }

        [Required, DisplayName("Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
