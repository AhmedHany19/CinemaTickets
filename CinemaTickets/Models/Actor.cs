using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture Is required")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name Is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name Must be between 3 and 50 char")]

        public string? FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biograhpy Name Is required")]
        public string? Bio { get; set; }




    }
}
