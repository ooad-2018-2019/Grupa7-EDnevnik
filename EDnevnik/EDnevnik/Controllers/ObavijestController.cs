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
    public class ObavijestController : Controller
    {
        private readonly EDnevnikContext _context;

        public ObavijestController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Obavijest
        public async Task<IActionResult> Index()
        {
            var eDnevnikContext = _context.Obavijest.Include(o => o.Nastavnik);
            return View(await eDnevnikContext.ToListAsync());
        }

        // GET: Obavijest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.Obavijest
                .Include(o => o.Nastavnik)
                .FirstOrDefaultAsync(m => m.ObavijestId == id);
            if (obavijest == null)
            {
                return NotFound();
            }

            return View(obavijest);
        }

        // GET: Obavijest/Create
        public IActionResult Create()
        {
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: Obavijest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObavijestId,Text,Datum,NastavnikId")] Obavijest obavijest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obavijest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId", obavijest.NastavnikId);
            return View(obavijest);
        }

        // GET: Obavijest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.Obavijest.FindAsync(id);
            if (obavijest == null)
            {
                return NotFound();
            }
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId", obavijest.NastavnikId);
            return View(obavijest);
        }

        // POST: Obavijest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObavijestId,Text,Datum,NastavnikId")] Obavijest obavijest)
        {
            if (id != obavijest.ObavijestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obavijest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObavijestExists(obavijest.ObavijestId))
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
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId", obavijest.NastavnikId);
            return View(obavijest);
        }

        // GET: Obavijest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.Obavijest
                .Include(o => o.Nastavnik)
                .FirstOrDefaultAsync(m => m.ObavijestId == id);
            if (obavijest == null)
            {
                return NotFound();
            }

            return View(obavijest);
        }

        // POST: Obavijest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obavijest = await _context.Obavijest.FindAsync(id);
            _context.Obavijest.Remove(obavijest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObavijestExists(int id)
        {
            return _context.Obavijest.Any(e => e.ObavijestId == id);
        }
    }
}
