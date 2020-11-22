using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorManageLettings.Dto
{
    public class LandlordDto
    {
        public int Id { get; set; }
        [Required, DisplayName("Landlord Name")]
        public string Name { get; set; }

        [Required, DisplayName("Address")]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string Address3 { get; set; }
        [Required]
        public string Address4 { get; set; }
        public string Address5 { get; set; }

        [Required, DisplayName("Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
