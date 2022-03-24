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
    public class AldeiaController : Controller
    {
        private readonly TabaContext _context;

        public AldeiaController(TabaContext context)
        {
            _context = context;
        }

        // GET: Aldeia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aldeias.ToListAsync());
        }

        // GET: Aldeia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aldeia = await _context.Aldeias
                .FirstOrDefaultAsync(m => m.Id_Aldeia == id);
            if (aldeia == null)
            {
                return NotFound();
            }

            return View(aldeia);
        }

        // GET: Aldeia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aldeia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Aldeia,Nome,Responsavel,localizacao")] Aldeia aldeia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aldeia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aldeia);
        }

        // GET: Aldeia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aldeia = await _context.Aldeias.FindAsync(id);
            if (aldeia == null)
            {
                return NotFound();
            }
            return View(aldeia);
        }

        // POST: Aldeia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Aldeia,Nome,Responsavel,localizacao")] Aldeia aldeia)
        {
            if (id != aldeia.Id_Aldeia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aldeia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AldeiaExists(aldeia.Id_Aldeia))
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
            return View(aldeia);
        }

        // GET: Aldeia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aldeia = await _context.Aldeias
                .FirstOrDefaultAsync(m => m.Id_Aldeia == id);
            if (aldeia == null)
            {
                return NotFound();
            }

            return View(aldeia);
        }

        // POST: Aldeia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aldeia = await _context.Aldeias.FindAsync(id);
            _context.Aldeias.Remove(aldeia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AldeiaExists(int id)
        {
            return _context.Aldeias.Any(e => e.Id_Aldeia == id);
        }
    }
}
