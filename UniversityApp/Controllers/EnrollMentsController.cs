#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Data;
using UnversityApp.Models;

namespace UniversityApp.Controllers
{
    public class EnrollMentsController : Controller
    {
        private readonly UniversityAppContext _context;

        public EnrollMentsController(UniversityAppContext context)
        {
            _context = context;
        }

        // GET: EnrollMents
        public async Task<IActionResult> Index()
        {
            var universityAppContext = _context.Enrollment.Include(e => e.Students).Include(e => e.Subjects);
            return View(await universityAppContext.ToListAsync());
        }

        // GET: EnrollMents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollMent = await _context.Enrollment
                .Include(e => e.Students)
                .Include(e => e.Subjects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollMent == null)
            {
                return NotFound();
            }

            return View(enrollMent);
        }

        // GET: EnrollMents/Create
        public IActionResult Create()
        {
            ViewData["Pom1Id"] = new SelectList(_context.Students, "Id", "FirstName");
            ViewData["Pom2Id"] = new SelectList(_context.Subjects, "Id", "EducationLevel");
            return View();
        }

        // POST: EnrollMents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pom1Id,Pom2Id,Semester,Year,Grade,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate,SeminalUrl,ProjectUrl")] EnrollMent enrollMent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollMent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pom1Id"] = new SelectList(_context.Students, "Id", "FirstName", enrollMent.Pom1Id);
            ViewData["Pom2Id"] = new SelectList(_context.Subjects, "Id", "EducationLevel", enrollMent.Pom2Id);
            return View(enrollMent);
        }

        // GET: EnrollMents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollMent = await _context.Enrollment.FindAsync(id);
            if (enrollMent == null)
            {
                return NotFound();
            }
            ViewData["Pom1Id"] = new SelectList(_context.Students, "Id", "FirstName", enrollMent.Pom1Id);
            ViewData["Pom2Id"] = new SelectList(_context.Subjects, "Id", "EducationLevel", enrollMent.Pom2Id);
            return View(enrollMent);
        }

        // POST: EnrollMents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pom1Id,Pom2Id,Semester,Year,Grade,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate,SeminalUrl,ProjectUrl")] EnrollMent enrollMent)
        {
            if (id != enrollMent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollMent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollMentExists(enrollMent.Id))
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
            ViewData["Pom1Id"] = new SelectList(_context.Students, "Id", "FirstName", enrollMent.Pom1Id);
            ViewData["Pom2Id"] = new SelectList(_context.Subjects, "Id", "EducationLevel", enrollMent.Pom2Id);
            return View(enrollMent);
        }

        // GET: EnrollMents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollMent = await _context.Enrollment
                .Include(e => e.Students)
                .Include(e => e.Subjects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollMent == null)
            {
                return NotFound();
            }

            return View(enrollMent);
        }

        // POST: EnrollMents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollMent = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollMent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollMentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
