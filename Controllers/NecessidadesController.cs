using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taba_Digital.Data;
using Taba_Digital.Models;

namespace Taba_Digital.Controllers
{
    public class NecessidadesController : Controller
    {
        private readonly TabaContext _context;

        public NecessidadesController(TabaContext context)
        {
            _context = context;
        }

        // GET: Necessidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Necessidades.ToListAsync());
        }

        // GET: Necessidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var necessidades = await _context.Necessidades
                .FirstOrDefaultAsync(m => m.Id_Necessidades == id);
            if (necessidades == null)
            {
                return NotFound();
            }

            return View(necessidades);
        }

        // GET: Necessidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Necessidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Necessidades,Tipo")] Necessidades necessidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(necessidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(necessidades);
        }

        // GET: Necessidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var necessidades = await _context.Necessidades.FindAsync(id);
            if (necessidades == null)
            {
                return NotFound();
            }
            return View(necessidades);
        }

        // POST: Necessidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Necessidades,Tipo")] Necessidades necessidades)
        {
            if (id != necessidades.Id_Necessidades)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(necessidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NecessidadesExists(necessidades.Id_Necessidades))
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
            return View(necessidades);
        }

        // GET: Necessidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var necessidades = await _context.Necessidades
                .FirstOrDefaultAsync(m => m.Id_Necessidades == id);
            if (necessidades == null)
            {
                return NotFound();
            }

            return View(necessidades);
        }

        // POST: Necessidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var necessidades = await _context.Necessidades.FindAsync(id);
            _context.Necessidades.Remove(necessidades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NecessidadesExists(int id)
        {
            return _context.Necessidades.Any(e => e.Id_Necessidades == id);
        }
    }
}
