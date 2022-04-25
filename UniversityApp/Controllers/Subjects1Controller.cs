#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Data;
using UniversityApp.Krajno;
using UniversityApp.Models;
using UnversityApp.Models;

namespace UniversityApp.Controllers
{
    public class Subjects1Controller : Controller
    {
        private readonly UniversityAppContext _context;

        public Subjects1Controller(UniversityAppContext context)
        {
            _context = context;
        }

        // GET: Subjects1
        public async Task<IActionResult> Index(string Name,string Sid)
        {
           
                // Use LINQ to get list of genres.
                IQueryable<string> genreQuery = from m in _context.Subjects
                                                select m.Semester;
                var movies = from m in _context.Subjects
                             select m;

                if (!string.IsNullOrEmpty(Name))
                {
                    movies = movies.Where(s => s.Title!.Contains(Name));
                }

                if (!string.IsNullOrEmpty(Sid))
                {
                    movies = movies.Where(x => x.Semester == Sid);
                }

            var movieGenreVM = new SearchView
                {
                Semester = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Subjects = await movies.ToListAsync()
                };

                return View(movieGenreVM);
            


        }

        // GET: Subjects1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            
              var subjects = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            var teachers = await _context.Teachers
                         .FirstOrDefaultAsync(m=> m.Id == subjects.FirstTeacherId);
            var pomteachers= await _context.Teachers
                         .FirstOrDefaultAsync(m => m.Id == subjects.SecondTeacherId);
            if (subjects == null)
            {
                return NotFound();
            }

            var students= from m in _context.Enrollment
                         select m;

            students = students.Where(x => x.Pom1Id == id); //lista kaj so imam predmeti povrzani so studenti
            var pom_students = from m in _context.Students
                               select m;
            List<int> nova = new List<int>();
            foreach(var pom in pom_students)
            {
                foreach(var j in students)
                {
                    if(j.Pom2Id==pom.Id)
                    {
                        nova.Add(j.Pom2Id); 
                    }
                }
            }
            if (nova.Count > 0)
            {
                pom_students = pom_students.Where(t => nova.Contains(t.Id));
                subjects.Studenti = await pom_students.ToListAsync();
            }
          //  IQueryable<Students> studentii = from m in _context.Enrollment
                                      //       where id.Equals(m.Pom2Id)
                                          //   select m.Students;
                                           
            subjects.Teachers1.FirstName = teachers.FirstName;
            subjects.Teachers2.FirstName = pomteachers.FirstName;
          
            return View(subjects);
        }

        // GET: Subjects1/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Subjects1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Subjects subjects)
        {
            _context.Subjects.Add(subjects);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Subjects1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }
            return View(subjects);
        }

        // POST: Subjects1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Subjects subjects)
        {
            _context.Update(subjects);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Subjects1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // POST: Subjects1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjects = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
