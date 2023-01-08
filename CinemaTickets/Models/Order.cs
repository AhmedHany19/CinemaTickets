using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CinemaTickets.Models
{
    public class Order

    {

        public Order()
        {
            OrderDetail = new List<OrderDetail>();
        }
        public int Id { get; set; }

        [Display(Name = "Order No")]
        public string? OrderNo { get; set; }
       
        public string? Name { get; set; }

        [Display(Name = "Telephone")]
        public string? PhoneNo { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? City { get; set; }       
        [Required]
        public string? Address { get; set; }
        [MaxLength(5)]
        [MinLength(5)]
        [Display(Name = ("Zip Code"))]
        public string? ZipCode { get; set; }

        public DateTime OrderDate { get; set; }
        [Required]
        public string? CardType { get; set; }
        [Required]
        public string? CardName { get; set; }
        [Required]
        public string? CardNumber { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        [Required]
        public string? Cvv { get; set; }


        [Display(Name = "User Name")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }



        public virtual List<OrderDetail> OrderDetail { get; set; }


    }
}
