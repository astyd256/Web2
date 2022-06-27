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
    public class PatientsModelsController : Controller
    {
        private readonly lab_2_5Context _context;

        public PatientsModelsController(lab_2_5Context context)
        {
            _context = context;
        }

        // GET: PatientsModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.PatientsModel.ToListAsync());
        }

        // GET: PatientsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientsModel == null)
            {
                return NotFound();
            }

            var patientsModel = await _context.PatientsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientsModel == null)
            {
                return NotFound();
            }

            return View(patientsModel);
        }

        // GET: PatientsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] PatientsModel patientsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientsModel);
        }

        // GET: PatientsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientsModel == null)
            {
                return NotFound();
            }

            var patientsModel = await _context.PatientsModel.FindAsync(id);
            if (patientsModel == null)
            {
                return NotFound();
            }
            return View(patientsModel);
        }

        // POST: PatientsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] PatientsModel patientsModel)
        {
            if (id != patientsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsModelExists(patientsModel.Id))
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
            return View(patientsModel);
        }

        // GET: PatientsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientsModel == null)
            {
                return NotFound();
            }

            var patientsModel = await _context.PatientsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientsModel == null)
            {
                return NotFound();
            }

            return View(patientsModel);
        }

        // POST: PatientsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientsModel == null)
            {
                return Problem("Entity set 'lab_2_5Context.PatientsModel'  is null.");
            }
            var patientsModel = await _context.PatientsModel.FindAsync(id);
            if (patientsModel != null)
            {
                _context.PatientsModel.Remove(patientsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientsModelExists(int id)
        {
          return _context.PatientsModel.Any(e => e.Id == id);
        }
    }
}
