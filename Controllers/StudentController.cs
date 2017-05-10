using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_register.Data;
using school_register.Model.Entities;
using school_register.Services;
using school_register.ViewModels;

namespace school_register.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolRegisterDbContext _context;
        private readonly IViewModelMap _mapper;

        public StudentController(SchoolRegisterDbContext context, IViewModelMap mapper)
        {
            _context = context;    
            _mapper = mapper;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var schoolRegisterDbContext = _context.Student.Include(s => s.FkClassNavigation);
            return View(await schoolRegisterDbContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.FkClassNavigation)
                .SingleOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["FkClass"] = new SelectList(_context.Class, "ID", "Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentsViewModel studentVM)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.GetStudent(studentVM);

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkClass"] = new SelectList(_context.Class, "ID", "Name", studentVM.FkClass);
            return View(studentVM);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            var studentVM = _mapper.GetStudentVM(student);
            
            if (student == null)
            {
                return NotFound();
            }
            ViewData["FkClass"] = new SelectList(_context.Class, "ID", "Name", student.FkClass);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentsViewModel studentVM)
        {
            if (id != studentVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var student = _mapper.GetStudent(studentVM);

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(studentVM.ID))
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
            ViewData["FkClass"] = new SelectList(_context.Class, "ID", "Name", studentVM.FkClass);
            return View(studentVM);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.FkClassNavigation)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
