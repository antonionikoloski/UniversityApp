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
    public class Teachers1Controller : Controller
    {
        private readonly UniversityAppContext _context;

        public Teachers1Controller(UniversityAppContext context)
        {
            _context = context;
        }

        // GET: Teachers1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        // GET: Teachers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // GET: Teachers1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Degree,AcademicRank,OfficeNumber,HireDate")] Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachers);
        }

        // GET: Teachers1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }
            return View(teachers);
        }

        // POST: Teachers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Degree,AcademicRank,OfficeNumber,HireDate")] Teachers teachers)
        {
            if (id != teachers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(teachers.Id))
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
            return View(teachers);
        }

        // GET: Teachers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // POST: Teachers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachers = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
        public async Task<IActionResult> LoginTeacher(int id)
        {
            var teachers = await _context.Teachers
               .FirstOrDefaultAsync(m => m.Id == id);
            var students = from m in _context.Subjects
                           select m;

            students = students.Where(x => x.FirstTeacherId == id);
            var students1 = from m in _context.Subjects
                           select m;

            students1 = students1.Where(x => x.SecondTeacherId == id);


          
            teachers.Subjects = await students1.ToListAsync();
            teachers.Subjects2=await students.ToListAsync();
            return View(teachers);
        }
        public async Task<IActionResult> LoginTeacherListStudents(int id)
        {
            var predmeti = from m in _context.Enrollment
                           select m;
            predmeti = predmeti.Where(x => x.Pom2Id == id);
            var student = from m in _context.Students
                          select m;
            List<int> nova = new List<int>();
            foreach (var pom in predmeti)
            {
                foreach (var j in student)
                {
                    if (pom.Pom1Id == j.Id)
                    {
                        nova.Add(j.Id);
                    }
                }
            }
            student = student.Where(t => nova.Contains(t.Id));
            var teachers = await _context.Teachers
         .FirstOrDefaultAsync(m => m.Id == id);
          teachers.Students= await student.ToListAsync();
            teachers.Enrollment = await predmeti.ToListAsync();
            return View(teachers);
        }
        public async Task<IActionResult> LoginTeacherDetailsStudents(int id)
        {
            var students = await _context.Students
                        .FirstOrDefaultAsync(m => m.Id == id);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveGrade(int id,int Grade)
        {
            var students = await _context.Enrollment
                      .FirstOrDefaultAsync(m => m.Id == id);
            students.Grade = Grade;
            _context.Update(students);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SavePoints(int id, int Points)
        {
            var students = await _context.Enrollment
                      .FirstOrDefaultAsync(m => m.Id == id);
            students.ExamPoints = Points;
            _context.Update(students);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SaveDate(int id, DateTime Date)
        {
            var students = await _context.Enrollment
                      .FirstOrDefaultAsync(m => m.Id == id);
            students.FinishDate = Date;
            _context.Update(students);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
