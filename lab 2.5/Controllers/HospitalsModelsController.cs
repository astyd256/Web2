using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_2._5.Data;
using lab_2._5.Models;

namespace lab_2._5.Controllers
{
    public class HospitalsModelsController : Controller
    {
        private readonly lab_2_5Context _context;

        public HospitalsModelsController(lab_2_5Context context)
        {
            _context = context;
        }

        // GET: HospitalsModels
        public async Task<IActionResult> Index()
        {
              return _context.HospitalsModel != null ? 
                          View(await _context.HospitalsModel.ToListAsync()) :
                          Problem("Entity set 'lab_2_5Context.HospitalsModel'  is null.");
        }

        // GET: HospitalsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HospitalsModel == null)
            {
                return NotFound();
            }

            var hospitalsModel = await _context.HospitalsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalsModel == null)
            {
                return NotFound();
            }

            return View(hospitalsModel);
        }

        // GET: HospitalsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HospitalsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] HospitalsModel hospitalsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitalsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitalsModel);
        }

        // GET: HospitalsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HospitalsModel == null)
            {
                return NotFound();
            }

            var hospitalsModel = await _context.HospitalsModel.FindAsync(id);
            if (hospitalsModel == null)
            {
                return NotFound();
            }
            return View(hospitalsModel);
        }

        // POST: HospitalsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] HospitalsModel hospitalsModel)
        {
            if (id != hospitalsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitalsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalsModelExists(hospitalsModel.Id))
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
            return View(hospitalsModel);
        }

        // GET: HospitalsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HospitalsModel == null)
            {
                return NotFound();
            }

            var hospitalsModel = await _context.HospitalsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalsModel == null)
            {
                return NotFound();
            }

            return View(hospitalsModel);
        }

        // POST: HospitalsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HospitalsModel == null)
            {
                return Problem("Entity set 'lab_2_5Context.HospitalsModel'  is null.");
            }
            var hospitalsModel = await _context.HospitalsModel.FindAsync(id);
            if (hospitalsModel != null)
            {
                _context.HospitalsModel.Remove(hospitalsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalsModelExists(int id)
        {
          return (_context.HospitalsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
