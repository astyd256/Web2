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
    public class DoctorsModelsController : Controller
    {
        private readonly lab_2_5Context _context;

        public DoctorsModelsController(lab_2_5Context context)
        {
            _context = context;
        }

        // GET: DoctorsModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.DoctorsModel.ToListAsync());
        }

        // GET: DoctorsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorsModel == null)
            {
                return NotFound();
            }

            var doctorsModel = await _context.DoctorsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsModel == null)
            {
                return NotFound();
            }

            return View(doctorsModel);
        }

        // GET: DoctorsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Speciality")] DoctorsModel doctorsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorsModel);
        }

        // GET: DoctorsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorsModel == null)
            {
                return NotFound();
            }

            var doctorsModel = await _context.DoctorsModel.FindAsync(id);
            if (doctorsModel == null)
            {
                return NotFound();
            }
            return View(doctorsModel);
        }

        // POST: DoctorsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Speciality")] DoctorsModel doctorsModel)
        {
            if (id != doctorsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsModelExists(doctorsModel.Id))
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
            return View(doctorsModel);
        }

        // GET: DoctorsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorsModel == null)
            {
                return NotFound();
            }

            var doctorsModel = await _context.DoctorsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsModel == null)
            {
                return NotFound();
            }

            return View(doctorsModel);
        }

        // POST: DoctorsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorsModel == null)
            {
                return Problem("Entity set 'lab_2_5Context.DoctorsModel'  is null.");
            }
            var doctorsModel = await _context.DoctorsModel.FindAsync(id);
            if (doctorsModel != null)
            {
                _context.DoctorsModel.Remove(doctorsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsModelExists(int id)
        {
          return _context.DoctorsModel.Any(e => e.Id == id);
        }
    }
}
