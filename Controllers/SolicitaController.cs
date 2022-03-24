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
    public class SolicitaController : Controller
    {
        private readonly TabaContext _context;

        public SolicitaController(TabaContext context)
        {
            _context = context;
        }

        // GET: Solicita
        public async Task<IActionResult> Index()
        {
            var tabaContext = _context.Solicita.Include(s => s.aldeia).Include(s => s.necessidades);
            return View(await tabaContext.ToListAsync());
        }

        // GET: Solicita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicita = await _context.Solicita
                .Include(s => s.aldeia)
                .Include(s => s.necessidades)
                .FirstOrDefaultAsync(m => m.Id_Solicita == id);
            if (solicita == null)
            {
                return NotFound();
            }

            return View(solicita);
        }

        // GET: Solicita/Create
        public IActionResult Create()
        {
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome");
            ViewData["NecessidadesId_necessidades"] = new SelectList(_context.Necessidades, "Id_Necessidades", "Tipo");
            return View();
        }

        // POST: Solicita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Solicita,Descricao,AldeiaId_Aldeia,NecessidadesId_necessidades")] Solicita solicita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome", solicita.AldeiaId_Aldeia);
            ViewData["NecessidadesId_necessidades"] = new SelectList(_context.Necessidades, "Id_Necessidades", "Tipo", solicita.NecessidadesId_necessidades);
            return View(solicita);
        }

        // GET: Solicita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicita = await _context.Solicita.FindAsync(id);
            if (solicita == null)
            {
                return NotFound();
            }
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome", solicita.AldeiaId_Aldeia);
            ViewData["NecessidadesId_necessidades"] = new SelectList(_context.Necessidades, "Id_Necessidades", "Tipo", solicita.NecessidadesId_necessidades);
            return View(solicita);
        }

        // POST: Solicita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Solicita,Descricao,AldeiaId_Aldeia,NecessidadesId_necessidades")] Solicita solicita)
        {
            if (id != solicita.Id_Solicita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitaExists(solicita.Id_Solicita))
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
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome", solicita.AldeiaId_Aldeia);
            ViewData["NecessidadesId_necessidades"] = new SelectList(_context.Necessidades, "Id_Necessidades", "Tipo", solicita.NecessidadesId_necessidades);
            return View(solicita);
        }

        // GET: Solicita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicita = await _context.Solicita
                .Include(s => s.aldeia)
                .Include(s => s.necessidades)
                .FirstOrDefaultAsync(m => m.Id_Solicita == id);
            if (solicita == null)
            {
                return NotFound();
            }

            return View(solicita);
        }

        // POST: Solicita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicita = await _context.Solicita.FindAsync(id);
            _context.Solicita.Remove(solicita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitaExists(int id)
        {
            return _context.Solicita.Any(e => e.Id_Solicita == id);
        }
    }
}
