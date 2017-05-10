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
    public class BranchController : Controller
    {
        private readonly SchoolRegisterDbContext _context;
        private readonly IViewModelMap _mapper;

        public BranchController(SchoolRegisterDbContext context, IViewModelMap mapper)
        {
            _context = context;    
            _mapper = mapper;
        }

        // GET: Branch
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branch.ToListAsync());
        }

        // GET: Branch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch
                .Include(b => b.Classes)
                .SingleOrDefaultAsync(m => m.ID == id);

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
        public async Task<IActionResult> Create(BranchViewModel branchVM)
        {
            if (ModelState.IsValid)
            {
                branchVM.Icon = "default.png";
                var branch = _mapper.GetBranch(branchVM);

                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(branchVM);
        }

        // GET: Branch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch.SingleOrDefaultAsync(m => m.ID == id);
            var branchVM = _mapper.GetBranchVM(branch);

            if (branchVM == null)
            {
                return NotFound();
            }
            return View(branchVM);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BranchViewModel branchVM)
        {
            if (id != branchVM.ID)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    var branch = _mapper.GetBranch(branchVM);
                    
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branchVM.ID))
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
            return View(branchVM);
        }

        // GET: Branch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch
                .SingleOrDefaultAsync(m => m.ID == id);

            var branchVM = _mapper.GetBranchVM(branch);

            if (branchVM == null)
            {
                return NotFound();
            }
            return View(branchVM);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var branch = await _context.Branch.SingleOrDefaultAsync(m => m.ID == id);
            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BranchExists(int? id)
        {
            return _context.Branch.Any(e => e.ID == id);
        }
    }
}
