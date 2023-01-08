using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaTickets.Data;
using CinemaTickets.Models;
using CinemaTickets.ViewModel;

namespace CinemaTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = new MoviesViewModel
            {
                Movie = new Movie(),
                Movies = _context.Movies.Include(m => m.Actor).Include(m => m.Cinema).Include(m => m.Producer).ToList(),
            };
        
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Actor)
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }








        // GET: Movies/Create
        
        public IActionResult Create()
        {
            ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(_context.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "FullName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,ImageURL,StartDate,EndDate,MovieCategory,ActorId,CinemaId,ProducerId")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(_context.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "FullName");
                return View(movie);

                
            }
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(_context.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "FullName");
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Price,ImageURL,StartDate,EndDate,MovieCategory,ActorId,CinemaId,ProducerId")] Movie movie)
        {
            if (id != movie.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cinemas = new SelectList(_context.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(_context.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "FullName");
            return View(movie);
        }

       

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        private bool MovieExists(string id)
        {
          return _context.Movies.Any(e => e.Name == id);
        }
    }
}
