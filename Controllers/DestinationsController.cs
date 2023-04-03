using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MDSProject.Data;
using MDSProject.Models;

namespace MDSProject.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly MDSProjectContext _context;

        public DestinationsController(MDSProjectContext context)
        {
            _context = context;
        }

        // GET: Destinations
        public async Task<IActionResult> Index(string searchString, string destinationExpensiveness)
        {
            if (_context.Destinations == null)
            {
                return Problem("Entity set 'MDSProjectContext.Destinations'  is null.");
            }

            IQueryable<string> expensivenessQuery = from m in _context.Destinations
                                                    orderby m.Expensiveness
                                                    select m.Expensiveness;

            var destination = from m in _context.Destinations
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                destination = destination.Where(s => s.City!.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(destinationExpensiveness))
            {
                destination = destination.Where(x => x.Expensiveness == destinationExpensiveness);
            }

            var destinationExpensivenessVM = new DestinationExpensivenessViewModel
            {
                Expensiveness = new SelectList(await expensivenessQuery.Distinct().ToListAsync()),
                Destinations = await destination.ToListAsync()
            };
            return View(destinationExpensivenessVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Destinations == null)
            {
                return NotFound();
            }

            var destinations = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinations == null)
            {
                return NotFound();
            }

            return View(destinations);
        }

        // GET: Destinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,Country,Best_Months_to_go,Expensiveness")] Destinations destinations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinations);
        }

        // GET: Destinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Destinations == null)
            {
                return NotFound();
            }

            var destinations = await _context.Destinations.FindAsync(id);
            if (destinations == null)
            {
                return NotFound();
            }
            return View(destinations);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Country,Best_Months_to_go,Expensiveness")] Destinations destinations)
        {
            if (id != destinations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationsExists(destinations.Id))
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
            return View(destinations);
        }

        // GET: Destinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Destinations == null)
            {
                return NotFound();
            }

            var destinations = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinations == null)
            {
                return NotFound();
            }

            return View(destinations);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Destinations == null)
            {
                return Problem("Entity set 'MDSProjectContext.Destinations'  is null.");
            }
            var destinations = await _context.Destinations.FindAsync(id);
            if (destinations != null)
            {
                _context.Destinations.Remove(destinations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationsExists(int id)
        {
          return (_context.Destinations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
