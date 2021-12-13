using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstMVCApp.Data;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers
{
    public class FilmiesController : Controller
    {
        private readonly MyFirstMVCAppContext _context;

        public FilmiesController(MyFirstMVCAppContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index(string id)
        //{
        //    var movies = from x in _context.Filmy select x;
        //    if(!String.IsNullOrEmpty(id))
        //    {
        //        movies = movies.Where(s=> s.Name!.Contains(id));
        //    }
        //    return View(await movies.ToListAsync());
        //}
        public async Task<IActionResult> Index(string GatunekFilmu, string SearchString)
        {
            IQueryable<string> gatunekQuery = from m in _context.Filmy orderby m.Genre select m.Genre;

            var movies = from m in _context.Filmy select m;
            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s=>s.Name!.Contains(SearchString));
            }
            if(!string.IsNullOrEmpty(GatunekFilmu))
            {
                movies = movies.Where(d=>d.Genre.Contains(GatunekFilmu));
            }

            var movieGenreVM = new FilmyGatunekModel
            {
                Gatunki = new SelectList(await gatunekQuery.Distinct().ToListAsync()),
                Filmy = await movies.ToListAsync()
            };
            return View(movieGenreVM);
        }

        // GET: Filmies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // GET: Filmies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Genre,Price,Rating")] Filmy filmy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmy);
        }

        // GET: Filmies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy.FindAsync(id);
            if (filmy == null)
            {
                return NotFound();
            }
            return View(filmy);
        }

        // POST: Filmies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Genre,Price")] Filmy filmy)
        {
            if (id != filmy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmyExists(filmy.Id))
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
            return View(filmy);
        }

        // GET: Filmies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // POST: Filmies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmy = await _context.Filmy.FindAsync(id);
            _context.Filmy.Remove(filmy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmyExists(int id)
        {
            return _context.Filmy.Any(e => e.Id == id);
        }
    }
}
