﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jossue_Ayala.Data;

namespace Jossue_Ayala.Models
{
    public class CarrerasController : Controller
    {
        private readonly Jossue_AyalaContext _context;

        public CarrerasController(Jossue_AyalaContext context)
        {
            _context = context;
        }

        // GET: Carreras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrera.ToListAsync());
        }

        // GET: Carreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carrera
                .FirstOrDefaultAsync(m => m.IdCarrera == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrera,Nombre_Carrera,Campus,Numero_Semestres")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carrera.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            return View(carrera);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarrera,Nombre_Carrera,Campus,Numero_Semestres")] Carrera carrera)
        {
            if (id != carrera.IdCarrera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraExists(carrera.IdCarrera))
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
            return View(carrera);
        }

        // GET: Carreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carrera
                .FirstOrDefaultAsync(m => m.IdCarrera == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrera = await _context.Carrera.FindAsync(id);
            if (carrera != null)
            {
                _context.Carrera.Remove(carrera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraExists(int id)
        {
            return _context.Carrera.Any(e => e.IdCarrera == id);
        }
    }
}
