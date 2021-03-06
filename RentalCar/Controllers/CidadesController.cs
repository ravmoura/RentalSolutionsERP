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
    public class CidadesController : Controller
    {
        private readonly RentalCarContext _context;

        public CidadesController(RentalCarContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            if (_context.Cidades != null)
            {
                var databaseContext = _context.Cidades.Include(c => c.Estado).OrderBy(x => x.Nome);
                return View(await databaseContext.ToListAsync());
            }                                  
            return Problem("Entity set 'RentalCarContext.Cidades'  is null.");
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.Include(c => c.Estado).FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            if (_context.Cidades != null)
            {
                ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome");                
            }
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IdEstado,Estado")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                TempData["message"] = cidade.GetType().Name + Util.InsertMsg;

                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", cidade.IdEstado);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.Include(c => c.Estado).FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", cidade.IdEstado);
            
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IdEstado")] Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                    TempData["message"] = cidade.GetType().Name + Util.UpdateMsg;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.Id))
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
            ViewData["IdEstado"] = new SelectList(_context.Estados, "Id", "Nome", cidade.IdEstado);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var databaseContext = _context.Cidades.Include(c => c.Estado);
            var cidade = await databaseContext.FirstOrDefaultAsync(m => m.Id == id);
            
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cidades == null)
            {
                return Problem("Entity set 'RentalCarContext.Cidades'  is null.");
            }
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidades.Remove(cidade);
                await _context.SaveChangesAsync();
                TempData["message"] = cidade.GetType().Name + Util.DeleteMsg;
            }            
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
            return (_context.Cidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
