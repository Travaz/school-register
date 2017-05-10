using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_register.Data;
using school_register.Services;
using school_register.ViewModels;

namespace school_register.Controllers
{
    public class ClassController : Controller
    {
        private readonly SchoolRegisterDbContext _context;
        private readonly IViewModelMap _mapper;

        public ClassController(SchoolRegisterDbContext context, IViewModelMap mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {
            var schoolRegisterDbContext = _context.Class
                .Include(c => c.FkBranchNavigation)
                .Include(c => c.FkRoomNavigation);
            return View(await schoolRegisterDbContext.ToListAsync());
        }

        // GET: Class/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _class = await _context.Class
                .Include(c => c.FkBranchNavigation)
                .Include(c => c.FkRoomNavigation)
                .Include(c => c.Students)
                .SingleOrDefaultAsync(m => m.ID == id);

            if (_class == null)
            {
                return NotFound();
            }

            return View(_class);
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            ViewData["FkBranch"] = new SelectList(_context.Branch, "ID", "Name");
            ViewData["FkRoom"] = new SelectList(_context.Room, "ID", "NumeroAula");
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassViewModel classVM)
        {
            if (ModelState.IsValid)
            {
                var _class = _mapper.GetClass(classVM);

                _context.Add(_class);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkBranch"] = new SelectList(_context.Branch, "ID", "Name", classVM.FkBranch);
            ViewData["FkRoom"] = new SelectList(_context.Room, "ID", "NumeroAula", classVM.FkRoom);
            return View(classVM);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _class = await _context.Class.SingleOrDefaultAsync(m => m.ID == id);
            var _classVM = _mapper.GetClassVM(_class);

            if (_classVM == null)
            {
                return NotFound();
            }
            ViewData["FkBranch"] = new SelectList(_context.Branch, "ID", "Name", _classVM.FkBranch);
            ViewData["FkRoom"] = new SelectList(_context.Room, "ID", "NumeroAula", _classVM.FkRoom);
            return View(_classVM);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ClassViewModel classVM)
        {
            if (id != classVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _class = _mapper.GetClass(classVM);

                    _context.Update(_class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(classVM.ID))
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
            ViewData["FkBranch"] = new SelectList(_context.Branch, "ID", "Name", classVM.FkBranch);
            ViewData["FkRoom"] = new SelectList(_context.Room, "ID", "NumeroAula", classVM.FkRoom);
            return View(classVM);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _class = await _context.Class
                .Include(c => c.FkBranchNavigation)
                .Include(c => c.FkRoomNavigation)
                .SingleOrDefaultAsync(m => m.ID == id);

            var classVM = _mapper.GetClassVM(_class);

            if (classVM == null)
            {
                return NotFound();
            }

            return View(classVM);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var _class = await _context.Class.SingleOrDefaultAsync(m => m.ID == id);
            _context.Class.Remove(_class);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClassExists(int? id)
        {
            return _context.Class.Any(e => e.ID == id);
        }
    }
}
