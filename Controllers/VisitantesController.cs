using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistCadVisita.API.Data;

namespace SistCadVisita.API.Controllers
{
    public class VisitantesController : Controller
    {
        private readonly DataContext _context;

        public VisitantesController(DataContext context)
        {
            _context = context;
        }

        // GET: Visitantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visitante.ToListAsync());
        }

        // GET: Visitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitante
                .FirstOrDefaultAsync(m => m.VisitanteId == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // GET: Visitantes/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitanteId,Nome,Cpf,Email,Celular")] Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitante);
        }

        // GET: Visitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitante.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }
            return View(visitante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitanteId,Nome,Cpf,Email,Celular")] Visitante visitante)
        {
            if (id != visitante.VisitanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitanteExists(visitante.VisitanteId))
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
            return View(visitante);
        }

        // GET: Visitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitante
                .FirstOrDefaultAsync(m => m.VisitanteId == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitante = await _context.Visitante.FindAsync(id);
            if (visitante != null)
            {
                _context.Visitante.Remove(visitante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitanteExists(int id)
        {
            return _context.Visitante.Any(e => e.VisitanteId == id);
        }
    }
}
