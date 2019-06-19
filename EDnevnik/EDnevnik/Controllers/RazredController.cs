using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDnevnik;
using EDnevnik.Models;

namespace EDnevnik.Controllers
{
    public class RazredController : Controller
    {
        private readonly EDnevnikContext _context;

        public RazredController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Razred
        public async Task<IActionResult> Index()
        {
            var eDnevnikContext = _context.Razred.Include(r => r.Nastavnik);
            return View(await eDnevnikContext.ToListAsync());
        }

        // GET: Razred/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razred = await _context.Razred
                .Include(r => r.Nastavnik)
                .FirstOrDefaultAsync(m => m.RazredId == id);
            if (razred == null)
            {
                return NotFound();
            }

            return View(razred);
        }

        // GET: Razred/Create
        public IActionResult Create()
        {
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "ImePrezime");
            return View();
        }

        // POST: Razred/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RazredId,NastavnikId,Broj")] Razred razred)
        {
            if (ModelState.IsValid)
            {
                _context.Add(razred);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "ImePrezime", razred.NastavnikId);
            return View(razred);
        }

        // GET: Razred/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razred = await _context.Razred.FindAsync(id);
            if (razred == null)
            {
                return NotFound();
            }
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "ImePrezime", razred.NastavnikId);
            return View(razred);
        }

        // POST: Razred/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RazredId,NastavnikId,Broj")] Razred razred)
        {
            if (id != razred.RazredId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(razred);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazredExists(razred.RazredId))
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
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "ImePrezime", razred.NastavnikId);
            return View(razred);
        }

        // GET: Razred/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razred = await _context.Razred
                .Include(r => r.Nastavnik)
                .FirstOrDefaultAsync(m => m.RazredId == id);
            if (razred == null)
            {
                return NotFound();
            }

            return View(razred);
        }

        // POST: Razred/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var razred = await _context.Razred.FindAsync(id);
            _context.Razred.Remove(razred);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RazredExists(int id)
        {
            return _context.Razred.Any(e => e.RazredId == id);
        }
    }
}
