using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Models
{
    public class Cinema
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        public string? Logo { get; set; }
        [Display(Name = "Cinema Name")]

        public string? Name { get; set; }
        public string? Description { get; set; }

        //Relationships

    }
}
