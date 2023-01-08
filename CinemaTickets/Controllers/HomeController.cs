using CinemaTickets.Data;
using CinemaTickets.Models;
using CinemaTickets.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;



        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Cart()
        {
            List<Movie>? movies = HttpContext.Session.Get<List<Movie>>("movies");
            if (movies == null)
            {
                movies = new List<Movie>();
            }
            return View(movies);
        }



        [HttpPost]
        public IActionResult AddToCart(string? name)
        {
            List<Movie> movies = new List<Movie>();

            if (name == null)
                return NotFound();

            var movie = _context.Movies
                .Include(x => x.Actor)
                .Include(x => x.Cinema)
                .Include(x => x.Producer)
                .FirstOrDefault(x => x.Name == name);

            if (movie == null)
                return NotFound();

            movies = HttpContext.Session.Get<List<Movie>>("movies");

            if (movies == null)
            {
                movies = new List<Movie>();
            }

            movies.Add(movie);
            HttpContext.Session.Set("movies", movies);

            return RedirectToAction("Index", "Movies");
        }



        public IActionResult RemoveFromCart(string? name)
        {
            List<Movie>? movies = HttpContext.Session.Get<List<Movie>>("movies");
            if (movies != null)
            {
                var movie = movies.FirstOrDefault(c => c.Name == name);
                if (movie != null)
                {
                    movies.Remove(movie);
                    HttpContext.Session.Set("movies", movies);
                }
            }
            return RedirectToAction(nameof(Cart));
        }
       


        [Authorize(Roles = "User")]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(Order anOrder)
        {
            var userId = _userManager.GetUserId(User);
            List<Movie>? movies = HttpContext.Session.Get<List<Movie>>("movies");
            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    OrderDetail orderDetails = new OrderDetail();
                    orderDetails.MovieName = movie.Name;
                    orderDetails.UserId = userId;
                    anOrder.OrderDetail.Add(orderDetails);
                }
            }
            anOrder.OrderNo = GetOrderNo();
            anOrder.UserId = userId;
            anOrder.OrderDate = DateTime.Now;

            _context.Orders.Add(anOrder);
            await _context.SaveChangesAsync();
            HttpContext.Session.Set("movies", new List<Movie>());
            return View();

        }

        public string GetOrderNo()
        {
            int rowCount = _context.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }





       

    }
}