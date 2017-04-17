using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_register.Data;
using school_register.Model.Entities;

namespace school_register.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolRegisterDbContext _context;

        public StudentController(SchoolRegisterDbContext context)
        {
            _context = context;    
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var schoolRegisterDbContext = _context.Student.Include(s => s.FkClassNavigation);
            return View(await schoolRegisterDbContext.ToListAsync());
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["FkClass"] = new SelectList(_context.Class, "Name", "Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiscalCode,Age,Birthday,Email,FkClass,Name,Surname")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkClass"] = new SelectList(_context.Class, "Name", "Name", student.FkClass);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.FiscalCode == id);
            if (student == null)
            {
                return NotFound();
            }

            ViewData["FkClass"] = new SelectList(_context.Class, "Name", "Name", student.FkClass);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FiscalCode,Age,Birthday,Email,FkClass,Name,Surname")] Student student)
        {
            if (id != student.FiscalCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.FiscalCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["FkClass"] = new SelectList(_context.Class, "Name", "Name", student.FkClass);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.FkClassNavigation)
                .SingleOrDefaultAsync(m => m.FiscalCode == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.FiscalCode == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.FiscalCode == id);
        }
    }
}