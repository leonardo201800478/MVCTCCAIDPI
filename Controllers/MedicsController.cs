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
    public class MedicsController : Controller
    {
        private readonly DataContext _context;

        public MedicsController(DataContext context)
        {
            _context = context;
        }

        // GET: Medics
        public async Task<IActionResult> Index()
        {
              return _context.Medics != null ? 
                          View(await _context.Medics.ToListAsync()) :
                          Problem("Entity set 'DataContext.Medics'  is null.");
        }

        // GET: Medics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medics == null)
            {
                return NotFound();
            }

            var medic = await _context.Medics
                .FirstOrDefaultAsync(m => m.MedicId == id);
            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // GET: Medics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicId,Name,Especialidade,Crm,Contato")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medic);
        }

        // GET: Medics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medics == null)
            {
                return NotFound();
            }

            var medic = await _context.Medics.FindAsync(id);
            if (medic == null)
            {
                return NotFound();
            }
            return View(medic);
        }

        // POST: Medics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicId,Name,Especialidade,Crm,Contato")] Medic medic)
        {
            if (id != medic.MedicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicExists(medic.MedicId))
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
            return View(medic);
        }

        // GET: Medics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medics == null)
            {
                return NotFound();
            }

            var medic = await _context.Medics
                .FirstOrDefaultAsync(m => m.MedicId == id);
            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // POST: Medics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medics == null)
            {
                return Problem("Entity set 'DataContext.Medics'  is null.");
            }
            var medic = await _context.Medics.FindAsync(id);
            if (medic != null)
            {
                _context.Medics.Remove(medic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicExists(int id)
        {
          return (_context.Medics?.Any(e => e.MedicId == id)).GetValueOrDefault();
        }
    }
}
