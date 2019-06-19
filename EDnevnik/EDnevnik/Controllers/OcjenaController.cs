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
    public class OcjenaController : Controller
    {
        private readonly EDnevnikContext _context;

        public OcjenaController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Ocjena
        public async Task<IActionResult> Index()
        {
            var eDnevnikContext = _context.Ocjena.Include(o => o.Predmet).Include(o => o.Ucenik);
            return View(await eDnevnikContext.ToListAsync());
        }

        // GET: Ocjena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocjena = await _context.Ocjena
                .Include(o => o.Predmet)
                .Include(o => o.Ucenik)
                .FirstOrDefaultAsync(m => m.OcjenaId == id);
            if (ocjena == null)
            {
                return NotFound();
            }

            return View(ocjena);
        }

        // GET: Ocjena/Create
        public IActionResult Create()
        {
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv");
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime");
            return View();
        }

        // POST: Ocjena/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OcjenaId,UcenikId,PredmetId,Vrijednost,Datum")] Ocjena ocjena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocjena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv", ocjena.PredmetId);
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime", ocjena.UcenikId);
            return View(ocjena);
        }

        // GET: Ocjena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocjena = await _context.Ocjena.FindAsync(id);
            if (ocjena == null)
            {
                return NotFound();
            }
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv", ocjena.PredmetId);
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime", ocjena.UcenikId);
            return View(ocjena);
        }

        // POST: Ocjena/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OcjenaId,UcenikId,PredmetId,Vrijednost,Datum")] Ocjena ocjena)
        {
            if (id != ocjena.OcjenaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocjena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcjenaExists(ocjena.OcjenaId))
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
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv", ocjena.PredmetId);
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime", ocjena.UcenikId);
            return View(ocjena);
        }

        // GET: Ocjena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocjena = await _context.Ocjena
                .Include(o => o.Predmet)
                .Include(o => o.Ucenik)
                .FirstOrDefaultAsync(m => m.OcjenaId == id);
            if (ocjena == null)
            {
                return NotFound();
            }

            return View(ocjena);
        }

        // POST: Ocjena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocjena = await _context.Ocjena.FindAsync(id);
            _context.Ocjena.Remove(ocjena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcjenaExists(int id)
        {
            return _context.Ocjena.Any(e => e.OcjenaId == id);
        }
    }
}
