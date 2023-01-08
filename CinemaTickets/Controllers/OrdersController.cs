using CinemaTickets.Data;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CinemaTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;



        public OrdersController(ILogger<OrdersController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_context.Orders.Include(x => x.User).ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: Order/Delete/5
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductTypes'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            TempData["delete"] = "Order type has been deleted";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult OrderDetails()
        {
            return View(_context.OrderDetails.Include(x=>x.Movie).Include(x=>x.Movie.Cinema).Include(x => x.User).Include(x=>x.Order).ToList());
        }



    }
}
