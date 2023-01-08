using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }



        [Display(Name = "Order")]
        public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		public Order? Order { get; set; }



		[Display(Name = "Movie Name")]
        public string? MovieName { get; set; }
        [ForeignKey("MovieName")]
        public Movie? Movie { get; set; }


        [Display(Name = "User Name")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }


    }
}
