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
    public class ClassController : Controller
    {
        private readonly SchoolRegisterDbContext _context;

        public ClassController(SchoolRegisterDbContext context)
        {
            _context = context;    
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
        public async Task<IActionResult> Details(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var _class = await _context.Class
                .Include(c => c.FkBranchNavigation)
                .Include(c => c.FkRoomNavigation)
                .SingleOrDefaultAsync(m => m.Name == id);
            if (_class == null)
            {
                return NotFound();
            }

            return View(_class);
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            ViewData["FkBranch"] = new SelectList(_context.Branch, "Name", "Name");
            ViewData["FkRoom"] = new SelectList(_context.Room, "NumeroAula", "NumeroAula");
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FkBranch,FkRoom")] Class _class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_class);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkBranch"] = new SelectList(_context.Branch, "Name", "Name", _class.FkBranch);
            ViewData["FkRoom"] = new SelectList(_context.Room, "NumeroAula", "NumeroAula", _class.FkRoom);
            return View(_class);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var _class = await _context.Class.SingleOrDefaultAsync(m => m.Name == id);
            if (_class == null)
            {
                return NotFound();
            }
            ViewData["FkBranch"] = new SelectList(_context.Branch, "Name", "Name", _class.FkBranch);
            ViewData["FkRoom"] = new SelectList(_context.Room, "NumeroAula", "NumeroAula", _class.FkRoom);
            return View(_class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,FkBranch,FkRoom")] Class _class)
        {
            if (id != _class.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(_class.Name))
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
            ViewData["FkBranch"] = new SelectList(_context.Branch, "Name", "Name", _class.FkBranch);
            ViewData["FkRoom"] = new SelectList(_context.Room, "NumeroAula", "NumeroAula", _class.FkRoom);
            return View(_class);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var _class = await _context.Class
                .Include(c => c.FkBranchNavigation)
                .Include(c => c.FkRoomNavigation)
                .SingleOrDefaultAsync(m => m.Name == id);
            if (_class == null)
            {
                return NotFound();
            }

            return View(_class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var _class = await _context.Class.SingleOrDefaultAsync(m => m.Name == id);
            _context.Class.Remove(_class);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClassExists(string id)
        {
            return _context.Class.Any(e => e.Name == id);
        }
    }
}
