using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]

        public string FullName { get; set; }
        [Display(Name = "Biography")]

        public string Bio { get; set; }

        //Relationships

    }
}
