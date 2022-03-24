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
    public class DoacoesController : Controller
    {
        private readonly TabaContext _context;

        public DoacoesController(TabaContext context)
        {
            _context = context;
        }

        // GET: Doacoes
        public async Task<IActionResult> Index()
        {
            var tabaContext = _context.Doacoes.Include(d => d.aldeia).Include(d => d.empresa).Include(d => d.pessoa);
            return View(await tabaContext.ToListAsync());
        }

        // GET: Doacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacoes = await _context.Doacoes
                .Include(d => d.aldeia)
                .Include(d => d.empresa)
                .Include(d => d.pessoa)
                .FirstOrDefaultAsync(m => m.Id_Doacoes == id);
            if (doacoes == null)
            {
                return NotFound();
            }

            return View(doacoes);
        }

        // GET: Doacoes/Create
        public IActionResult Create()
        {
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome");
            ViewData["EmpresaId_Empresa"] = new SelectList(_context.Empresas, "Id_Empresa", "Nome");
            ViewData["PessoaId_Pessoa"] = new SelectList(_context.Pessoa, "Id_Pessoa", "Nome");
            return View();
        }

        // POST: Doacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Doacoes,Data_contribuicoes,PessoaId_Pessoa,AldeiaId_Aldeia,EmpresaId_Empresa")] Doacoes doacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome", doacoes.AldeiaId_Aldeia);
            ViewData["EmpresaId_Empresa"] = new SelectList(_context.Empresas, "Id_Empresa", "Nome", doacoes.EmpresaId_Empresa);
            ViewData["PessoaId_Pessoa"] = new SelectList(_context.Pessoa, "Id_Pessoa", "Nome", doacoes.PessoaId_Pessoa);
            return View(doacoes);
        }

        // GET: Doacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacoes = await _context.Doacoes.FindAsync(id);
            if (doacoes == null)
            {
                return NotFound();
            }
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome", doacoes.AldeiaId_Aldeia);
            ViewData["EmpresaId_Empresa"] = new SelectList(_context.Empresas, "Id_Empresa", "Nome", doacoes.EmpresaId_Empresa);
            ViewData["PessoaId_Pessoa"] = new SelectList(_context.Pessoa, "Id_Pessoa", "Nome", doacoes.PessoaId_Pessoa);
            return View(doacoes);
        }

        // POST: Doacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Doacoes,Data_contribuicoes,PessoaId_Pessoa,AldeiaId_Aldeia,EmpresaId_Empresa")] Doacoes doacoes)
        {
            if (id != doacoes.Id_Doacoes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoacoesExists(doacoes.Id_Doacoes))
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
            ViewData["AldeiaId_Aldeia"] = new SelectList(_context.Aldeias, "Id_Aldeia", "Nome", doacoes.AldeiaId_Aldeia);
            ViewData["EmpresaId_Empresa"] = new SelectList(_context.Empresas, "Id_Empresa", "Nome", doacoes.EmpresaId_Empresa);
            ViewData["PessoaId_Pessoa"] = new SelectList(_context.Pessoa, "Id_Pessoa", "Nome", doacoes.PessoaId_Pessoa);
            return View(doacoes);
        }

        // GET: Doacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacoes = await _context.Doacoes
                .Include(d => d.aldeia)
                .Include(d => d.empresa)
                .Include(d => d.pessoa)
                .FirstOrDefaultAsync(m => m.Id_Doacoes == id);
            if (doacoes == null)
            {
                return NotFound();
            }

            return View(doacoes);
        }

        // POST: Doacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doacoes = await _context.Doacoes.FindAsync(id);
            _context.Doacoes.Remove(doacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoacoesExists(int id)
        {
            return _context.Doacoes.Any(e => e.Id_Doacoes == id);
        }
    }
}
