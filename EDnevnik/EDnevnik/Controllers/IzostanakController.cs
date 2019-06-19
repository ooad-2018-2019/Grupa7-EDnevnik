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
    public class IzostanakController : Controller
    {
        private readonly EDnevnikContext _context;

        public IzostanakController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Izostanak
        public async Task<IActionResult> Index()
        {
            var eDnevnikContext = _context.Izostanak.Include(i => i.Predmet).Include(i => i.Ucenik);
            return View(await eDnevnikContext.ToListAsync());
        }

        // GET: Izostanak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izostanak = await _context.Izostanak
                .Include(i => i.Predmet)
                .Include(i => i.Ucenik)
                .FirstOrDefaultAsync(m => m.IzostanakId == id);
            if (izostanak == null)
            {
                return NotFound();
            }

            return View(izostanak);
        }

        // GET: Izostanak/Create
        public IActionResult Create()
        {
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv");
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime");
            return View();
        }

        // POST: Izostanak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IzostanakId,UcenikId,PredmetId,Datum,Opravdan")] Izostanak izostanak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izostanak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv", izostanak.PredmetId);
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime", izostanak.UcenikId);
            return View(izostanak);
        }

        // GET: Izostanak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izostanak = await _context.Izostanak.FindAsync(id);
            if (izostanak == null)
            {
                return NotFound();
            }
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv", izostanak.PredmetId);
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime", izostanak.UcenikId);
            return View(izostanak);
        }

        // POST: Izostanak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IzostanakId,UcenikId,PredmetId,Datum,Opravdan")] Izostanak izostanak)
        {
            if (id != izostanak.IzostanakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izostanak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzostanakExists(izostanak.IzostanakId))
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
            ViewData["PredmetId"] = new SelectList(_context.Predmet, "PredmetId", "Naziv", izostanak.PredmetId);
            ViewData["UcenikId"] = new SelectList(_context.Ucenik, "KorisnikId", "ImePrezime", izostanak.UcenikId);
            return View(izostanak);
        }

        // GET: Izostanak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izostanak = await _context.Izostanak
                .Include(i => i.Predmet)
                .Include(i => i.Ucenik)
                .FirstOrDefaultAsync(m => m.IzostanakId == id);
            if (izostanak == null)
            {
                return NotFound();
            }

            return View(izostanak);
        }

        // POST: Izostanak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var izostanak = await _context.Izostanak.FindAsync(id);
            _context.Izostanak.Remove(izostanak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IzostanakExists(int id)
        {
            return _context.Izostanak.Any(e => e.IzostanakId == id);
        }
    }
}
