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
    public class LabsModelsController : Controller
    {
        private readonly lab_2_5Context _context;

        public LabsModelsController(lab_2_5Context context)
        {
            _context = context;
        }

        // GET: LabsModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.LabsModel.ToListAsync());
        }

        // GET: LabsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LabsModel == null)
            {
                return NotFound();
            }

            var labsModel = await _context.LabsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labsModel == null)
            {
                return NotFound();
            }

            return View(labsModel);
        }

        // GET: LabsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] LabsModel labsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labsModel);
        }

        // GET: LabsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LabsModel == null)
            {
                return NotFound();
            }

            var labsModel = await _context.LabsModel.FindAsync(id);
            if (labsModel == null)
            {
                return NotFound();
            }
            return View(labsModel);
        }

        // POST: LabsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] LabsModel labsModel)
        {
            if (id != labsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabsModelExists(labsModel.Id))
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
            return View(labsModel);
        }

        // GET: LabsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LabsModel == null)
            {
                return NotFound();
            }

            var labsModel = await _context.LabsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labsModel == null)
            {
                return NotFound();
            }

            return View(labsModel);
        }

        // POST: LabsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LabsModel == null)
            {
                return Problem("Entity set 'lab_2_5Context.LabsModel'  is null.");
            }
            var labsModel = await _context.LabsModel.FindAsync(id);
            if (labsModel != null)
            {
                _context.LabsModel.Remove(labsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabsModelExists(int id)
        {
          return _context.LabsModel.Any(e => e.Id == id);
        }
    }
}
