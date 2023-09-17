using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTCCAIDPI.Models;

namespace MVCTCCAIDPI.Controllers
{
    public class PacientsController : Controller
    {
        private readonly DataContext _context;

        public PacientsController(DataContext context)
        {
            _context = context;
        }

        // GET: Pacients
        public async Task<IActionResult> Index()
        {
              return _context.Pacients != null ? 
                          View(await _context.Pacients.ToListAsync()) :
                          Problem("Entity set 'DataContext.Pacients'  is null.");
        }

        // GET: Pacients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacients == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacients
                .FirstOrDefaultAsync(m => m.PacientId == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // GET: Pacients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacientId,Name,cpf,Identidade,Endereco,DataNasc")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacient);
        }

        // GET: Pacients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacients == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacients.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacientId,Name,cpf,Identidade,Endereco,DataNasc")] Pacient pacient)
        {
            if (id != pacient.PacientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientExists(pacient.PacientId))
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
            return View(pacient);
        }

        // GET: Pacients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacients == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacients
                .FirstOrDefaultAsync(m => m.PacientId == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacients == null)
            {
                return Problem("Entity set 'DataContext.Pacients'  is null.");
            }
            var pacient = await _context.Pacients.FindAsync(id);
            if (pacient != null)
            {
                _context.Pacients.Remove(pacient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientExists(int id)
        {
          return (_context.Pacients?.Any(e => e.PacientId == id)).GetValueOrDefault();
        }
    }
}
