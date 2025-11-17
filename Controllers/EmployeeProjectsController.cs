using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Models;

namespace ProjectTracker.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private readonly ProjectTrackerContext _context;

        public EmployeeProjectsController(ProjectTrackerContext context)
        {
            _context = context;
        }

        // GET: EmployeeProjects
        public async Task<IActionResult> Index()
        {
            var projectTrackerContext = _context.EmployeeProjects.Include(e => e.Employee).Include(e => e.Project);
            return View(await projectTrackerContext.ToListAsync());
        }

        // GET: EmployeeProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProjects = await _context.EmployeeProjects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeProjects == null)
            {
                return NotFound();
            }

            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,ProjectId")] EmployeeProjects employeeProjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeProjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeProjects.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProjects = await _context.EmployeeProjects.FindAsync(id);
            if (employeeProjects == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeProjects.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,ProjectId")] EmployeeProjects employeeProjects)
        {
            if (id != employeeProjects.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeProjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeProjectsExists(employeeProjects.EmployeeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeProjects.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProjects = await _context.EmployeeProjects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeProjects == null)
            {
                return NotFound();
            }

            return View(employeeProjects);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeProjects = await _context.EmployeeProjects.FindAsync(id);
            if (employeeProjects != null)
            {
                _context.EmployeeProjects.Remove(employeeProjects);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeProjectsExists(int id)
        {
            return _context.EmployeeProjects.Any(e => e.EmployeeId == id);
        }
    }
}
