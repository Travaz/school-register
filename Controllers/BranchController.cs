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
    public class BranchController : Controller
    {
        private readonly SchoolRegisterDbContext _context;

        public BranchController(SchoolRegisterDbContext context)
        {
            _context = context;    
        }

        // GET: Branch
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branch.ToListAsync());
        }

        // GET: Branch/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var branch = await _context.Branch
                .SingleOrDefaultAsync(m => m.Name == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // GET: Branch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,StartDate")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // GET: Branch/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var branch = await _context.Branch.SingleOrDefaultAsync(m => m.Name == id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,StartDate")] Branch branch)
        {
            if (id != branch.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.Name))
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
            return View(branch);
        }

        // GET: Branch/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == string.Empty)
            {
                return NotFound();
            }

            var branch = await _context.Branch
                .SingleOrDefaultAsync(m => m.Name == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var branch = await _context.Branch.SingleOrDefaultAsync(m => m.Name == id);
            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BranchExists(string id)
        {
            return _context.Branch.Any(e => e.Name == id);
        }
    }
}
