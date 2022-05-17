#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Areas.Identity.Data;
using UniversityApp.Data;
using UniversityApp.Krajno;
using UnversityApp.Models;

namespace UniversityApp.Controllers
{
    public class Students1Controller : Controller
    {
        private readonly UniversityAppContext _context;

        public Students1Controller(UniversityAppContext context)
        {
            _context = context;
        }

        // GET: Students1
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            

            return View(await _context.Students.ToListAsync());
           
        }

        // GET: Students1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentID,FirstName,LastName,EnrollmentDate,AcquiredCredits,CurrentSemestar,EducationLevel")] Students students,[Bind("Email,PasswordHash")] UniversityAppUser userce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                _context.Add(userce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentID,FirstName,LastName,EnrollmentDate,AcquiredCredits,CurrentSemestar,EducationLevel")] Students students)
        {
            if (id != students.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.Id))
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
            return View(students);
        }

        // GET: Students1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.FindAsync(id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> LoginStudent(int ID)
        {

            return View();
        }
        public async Task<IActionResult> LoginStudent1(int id)
        {
            var students =  await _context.Enrollment
               .FirstOrDefaultAsync(m => m.Pom1Id == id);

            var pom_students = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == students.Pom1Id);


            var students1 = from m in _context.Enrollment
                           select m;

            students1 = students1.Where(x => x.Pom1Id == id);
           var subjekati= from m in _context.Subjects
                          select m;
            List<int> nova = new List<int>();
            foreach (var pom in subjekati)
            {
                foreach (var j in students1)
                {
                    if (pom.Id == j.Pom2Id)
                    {
                        nova.Add(j.Pom2Id);
                    }
                }
            }
            subjekati = subjekati.Where(t => nova.Contains(t.Id));
            pom_students.Predmeti = await subjekati.ToListAsync();

            students1 = students1.Where(t => nova.Contains(t.Pom2Id));
            pom_students.EnrollMent = await students1.ToListAsync();

            return View(pom_students);
        }

        [HttpPost]
        public async Task<IActionResult> LoginStudentDetails(int id,IFormFile file)
        {
            string uniqueFileName = UploadedFile(file);
            
            var students3 = await _context.Enrollment
              .FirstOrDefaultAsync(m => m.Pom1Id == id);
            students3.SeminalUrl = uniqueFileName;
            _context.Update(students3);
            _context.SaveChanges();
           

         
            return View();
        }
        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        private string UploadedFile(IFormFile viewmodel)
        {
            string uniqueFileName = null;

            if (viewmodel != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/haah" );
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(viewmodel.FileName);
                string fileNameWithPath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    viewmodel.CopyTo(stream);
                }
            }
            return uniqueFileName;
        }
    }
    
}
