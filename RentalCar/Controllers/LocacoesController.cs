using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalCar.Data;
using RentalCar.Models;

namespace RentalCar.Controllers
{
    public class LocacoesController : Controller
    {
        private readonly RentalCarContext _context;

        public LocacoesController(RentalCarContext context)
        {
            _context = context;
        }

        // GET: Locacoes
        public async Task<IActionResult> Index()
        {
            var rentalCarContext = _context.Locacoes.Include(l => l.Carro).Include(l => l.Cliente).OrderBy(x => x.DataLocacao);
            return View(await rentalCarContext.ToListAsync());
        }

        // GET: Locacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locacoes == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacoes
                .Include(l => l.Carro)
                .Include(l => l.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // GET: Locacoes/Create
        public IActionResult Create()
        {
            ViewData["IdCarro"] = new SelectList(_context.Carros.OrderBy(c => c.Modelo), "Id", "Modelo");
            ViewData["IdCliente"] = new SelectList(_context.Clientes.OrderBy(c => c.Nome), "Id", "Nome");
            return View();
        }

        // POST: Locacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,IdCarro,Diaria,DataLocacao,DiasLocacao,DataDevolucao,ValorSeguro,observacao")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locacao);
                await _context.SaveChangesAsync();
                TempData["message"] = "Locação" + Util.InsertMsg;
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarro"] = new SelectList(_context.Carros.OrderBy(c => c.Modelo), "Id", "Modelo", locacao.IdCarro);
            ViewData["IdCliente"] = new SelectList(_context.Clientes.OrderBy(c => c.Nome), "Id", "Nome", locacao.IdCliente);
            return View(locacao);
        }

        // GET: Locacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locacoes == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }
            ViewData["IdCarro"] = new SelectList(_context.Carros.OrderBy(c => c.Modelo), "Id", "Modelo", locacao.IdCarro);
            ViewData["IdCliente"] = new SelectList(_context.Clientes.OrderBy(c => c.Nome), "Id", "Nome", locacao.IdCliente);
            return View(locacao);
        }

        // POST: Locacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdCarro,Diaria,DataLocacao,DiasLocacao,DataDevolucao,ValorSeguro,observacao")] Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacao);
                    await _context.SaveChangesAsync();
                    TempData["message"] = "Locação" + Util.UpdateMsg;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacaoExists(locacao.Id))
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
            ViewData["IdCarro"] = new SelectList(_context.Carros.OrderBy(c => c.Modelo), "Id", "Modelo", locacao.IdCarro);
            ViewData["IdCliente"] = new SelectList(_context.Clientes.OrderBy(c => c.Nome), "Id", "Celular", locacao.IdCliente);
            return View(locacao);
        }

        // GET: Locacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locacoes == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacoes
                .Include(l => l.Carro)
                .Include(l => l.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // POST: Locacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locacoes == null)
            {
                return Problem("Entity set 'RentalCarContext.Locacoes'  is null.");
            }
            var locacao = await _context.Locacoes.FindAsync(id);
            if (locacao != null)
            {
                _context.Locacoes.Remove(locacao);
                await _context.SaveChangesAsync();
                TempData["message"] = "Locação" + Util.DeleteMsg;
            }            
            return RedirectToAction(nameof(Index));
        }

        private bool LocacaoExists(int id)
        {
            return (_context.Locacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
