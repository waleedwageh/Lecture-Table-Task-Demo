using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assinment1.Models;

namespace assinment1.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ContextDb _context;

        public SectionsController(ContextDb context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var contextDb = _context.Sections.Include(s => s.Room).Include(s => s.course).Include(s => s.professor);
            return View(await contextDb.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Sections
                .Include(s => s.Room)
                .Include(s => s.course)
                .Include(s => s.professor)
                .FirstOrDefaultAsync(m => m.Section_Id == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            ViewData["Hall_Num"] = new SelectList(_context.ClassRooms, "Hall_Code", "Hall_Code");
            ViewData["Course_Code"] = new SelectList(_context.Courses, "Course_code", "Course_code");
            ViewData["Professor_Id"] = new SelectList(_context.Professors, "Professor_Id", "Professor_Id");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Section_Id,Professor_Id,Course_Code,FirstDay,LastDays,StartDate,EndDate,Hall_Num")] Sections sections)
        {
            var sectionsProf = _context.Sections.Where(s => s.professor.Professor_Id == sections.Professor_Id).ToList();
            var Profconfilct = sectionsProf.Any(s => s.StartDate == sections.StartDate && s.FirstDay == sections.FirstDay
            && s.LastDays == sections.LastDays);

            if (Profconfilct == true)
            {
                ModelState.AddModelError("", "Professor already Exist in this Section");
            }
            if (ModelState.IsValid)
            {
                _context.Add(sections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        


            ViewData["Hall_Num"] = new SelectList(_context.ClassRooms, "Hall_Code", "Hall_Code", sections.Hall_Num);
            ViewData["Course_Code"] = new SelectList(_context.Courses, "Course_code", "Course_code", sections.Course_Code);
            ViewData["Professor_Id"] = new SelectList(_context.Professors, "Professor_Id", "Professor_Id", sections.Professor_Id);
            return View(sections);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Sections.FindAsync(id);
            if (sections == null)
            {
                return NotFound();
            }
            ViewData["Hall_Num"] = new SelectList(_context.ClassRooms, "Hall_Code", "Hall_Code", sections.Hall_Num);
            ViewData["Course_Code"] = new SelectList(_context.Courses, "Course_code", "Course_code", sections.Course_Code);
            ViewData["Professor_Id"] = new SelectList(_context.Professors, "Professor_Id", "Professor_Id", sections.Professor_Id);
            return View(sections);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Section_Id,Professor_Id,Course_Code,FirstDay,LastDays,StartDate,EndDate,Hall_Num")] Sections sections)
        {
            if (id != sections.Section_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionsExists(sections.Section_Id))
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
            ViewData["Hall_Num"] = new SelectList(_context.ClassRooms, "Hall_Code", "Hall_Code", sections.Hall_Num);
            ViewData["Course_Code"] = new SelectList(_context.Courses, "Course_code", "Course_code", sections.Course_Code);
            ViewData["Professor_Id"] = new SelectList(_context.Professors, "Professor_Id", "Professor_Id", sections.Professor_Id);
            return View(sections);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Sections
                .Include(s => s.Room)
                .Include(s => s.course)
                .Include(s => s.professor)
                .FirstOrDefaultAsync(m => m.Section_Id == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sections = await _context.Sections.FindAsync(id);
            _context.Sections.Remove(sections);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionsExists(int id)
        {
            return _context.Sections.Any(e => e.Section_Id == id);
        }
    }
}
