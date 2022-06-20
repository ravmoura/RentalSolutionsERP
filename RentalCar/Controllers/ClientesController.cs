using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalCar.Models;
using RentalCar.Data;

namespace RentalCar.Controllers
{
    public class ClientesController : Controller
    {
        private readonly RentalCarContext _context;

        public ClientesController(RentalCarContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return _context.Clientes != null ?
                    View(await _context.Clientes.OrderBy(x => x.Nome).ToListAsync()) :
                    Problem("Lista de clientes em 'RentalCarContext.Clientes' não existe.");
            
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Telefone,Celular,Cnh,Rg,Cpf,Endereco")] Cliente cliente)
        {            
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                TempData["message"] = cliente.GetType().Name + Util.InsertMsg;
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);            
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {            
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }            
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
            
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Telefone,Celular,Cnh,Rg,Cpf,Endereco")] Cliente cliente)
        {
            if (id != cliente.Id || _context.Clientes == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    TempData["message"] = cliente.GetType().Name + Util.UpdateMsg;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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

            cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);            
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }
            
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);            
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Lista de clientes é nula.");
            }            
            var cliente = await _context.Clientes.FindAsync(id);
            //var locacao = await _context.Locacoes.FirstAsync(m => m.IdCliente == id && m.DataDevolucao == null);

            /*if (locacao != null)
            {
                TempData["message"] = cliente.GetType().Name + Util.ValidationFkMsg;
            }
            else */ 
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                TempData["message"] = cliente.GetType().Name + Util.DeleteMsg;
            }            
            return RedirectToAction(nameof(Index));            
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
