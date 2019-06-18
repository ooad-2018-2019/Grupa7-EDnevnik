﻿using System;
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
    public class PredmetController : Controller
    {
        private readonly EDnevnikContext _context;

        public PredmetController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Predmet
        public async Task<IActionResult> Index()
        {
            var eDnevnikContext = _context.Predmet.Include(p => p.Nastavnik);
            return View(await eDnevnikContext.ToListAsync());
        }

        // GET: Predmet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet
                .Include(p => p.Nastavnik)
                .FirstOrDefaultAsync(m => m.PredmetId == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // GET: Predmet/Create
        public IActionResult Create()
        {
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: Predmet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PredmetId,Naziv,Opis,Literatura,NastavnikId,Godina")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId", predmet.NastavnikId);
            return View(predmet);
        }

        // GET: Predmet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet.FindAsync(id);
            if (predmet == null)
            {
                return NotFound();
            }
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId", predmet.NastavnikId);
            return View(predmet);
        }

        // POST: Predmet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PredmetId,Naziv,Opis,Literatura,NastavnikId,Godina")] Predmet predmet)
        {
            if (id != predmet.PredmetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredmetExists(predmet.PredmetId))
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
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnik, "KorisnikId", "KorisnikId", predmet.NastavnikId);
            return View(predmet);
        }

        // GET: Predmet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet
                .Include(p => p.Nastavnik)
                .FirstOrDefaultAsync(m => m.PredmetId == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // POST: Predmet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predmet = await _context.Predmet.FindAsync(id);
            _context.Predmet.Remove(predmet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredmetExists(int id)
        {
            return _context.Predmet.Any(e => e.PredmetId == id);
        }
    }
}
