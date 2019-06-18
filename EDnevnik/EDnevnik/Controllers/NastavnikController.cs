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
    public class NastavnikController : Controller
    {
        private readonly EDnevnikContext _context;

        public NastavnikController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Nastavnik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nastavnik.ToListAsync());
        }

        // GET: Nastavnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nastavnik = await _context.Nastavnik
                .FirstOrDefaultAsync(m => m.KorisnikId == id);
            if (nastavnik == null)
            {
                return NotFound();
            }

            return View(nastavnik);
        }

        // GET: Nastavnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nastavnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KorisnikId,Ime,Prezime,Username,Password,DatumRodjenja,JMBG,PravoPristupa")] Nastavnik nastavnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nastavnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nastavnik);
        }

        // GET: Nastavnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nastavnik = await _context.Nastavnik.FindAsync(id);
            if (nastavnik == null)
            {
                return NotFound();
            }
            return View(nastavnik);
        }

        // POST: Nastavnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KorisnikId,Ime,Prezime,Username,Password,DatumRodjenja,JMBG,PravoPristupa")] Nastavnik nastavnik)
        {
            if (id != nastavnik.KorisnikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nastavnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NastavnikExists(nastavnik.KorisnikId))
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
            return View(nastavnik);
        }

        // GET: Nastavnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nastavnik = await _context.Nastavnik
                .FirstOrDefaultAsync(m => m.KorisnikId == id);
            if (nastavnik == null)
            {
                return NotFound();
            }

            return View(nastavnik);
        }

        // POST: Nastavnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nastavnik = await _context.Nastavnik.FindAsync(id);
            _context.Nastavnik.Remove(nastavnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NastavnikExists(int id)
        {
            return _context.Nastavnik.Any(e => e.KorisnikId == id);
        }
    }
}
