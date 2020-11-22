using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LettingsManager.WebSite.Models
{
    public class Landlord
    {
        public Landlord()
        {
            Houses = new HashSet<House>();
        }
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
        public virtual ICollection<House> Houses { get; set; }

    }
    public class LandlordInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}