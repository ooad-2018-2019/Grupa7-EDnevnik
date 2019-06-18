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
    public class RoditeljController : Controller
    {
        private readonly EDnevnikContext _context;

        public RoditeljController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Roditelj
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roditelj.ToListAsync());
        }

        // GET: Roditelj/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roditelj = await _context.Roditelj
                .FirstOrDefaultAsync(m => m.KorisnikId == id);
            if (roditelj == null)
            {
                return NotFound();
            }

            return View(roditelj);
        }

        // GET: Roditelj/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roditelj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KorisnikId,Ime,Prezime,Username,Password,DatumRodjenja,JMBG,PravoPristupa")] Roditelj roditelj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roditelj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roditelj);
        }

        // GET: Roditelj/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roditelj = await _context.Roditelj.FindAsync(id);
            if (roditelj == null)
            {
                return NotFound();
            }
            return View(roditelj);
        }

        // POST: Roditelj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KorisnikId,Ime,Prezime,Username,Password,DatumRodjenja,JMBG,PravoPristupa")] Roditelj roditelj)
        {
            if (id != roditelj.KorisnikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roditelj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoditeljExists(roditelj.KorisnikId))
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
            return View(roditelj);
        }

        // GET: Roditelj/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roditelj = await _context.Roditelj
                .FirstOrDefaultAsync(m => m.KorisnikId == id);
            if (roditelj == null)
            {
                return NotFound();
            }

            return View(roditelj);
        }

        // POST: Roditelj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roditelj = await _context.Roditelj.FindAsync(id);
            _context.Roditelj.Remove(roditelj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoditeljExists(int id)
        {
            return _context.Roditelj.Any(e => e.KorisnikId == id);
        }
    }
}
