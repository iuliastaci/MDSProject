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
    public class HotelsController : Controller
    {
        private readonly MDSProjectContext _context;

        public HotelsController(MDSProjectContext context)
        {
            _context = context;
        }

        // GET: Hotels
        public async Task<IActionResult> Index(string searchString, string hotelCity )
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'MDSProjectContext.Hotels'  is null.");
            }

            IQueryable<string> cityQuery = from m in _context.Hotels
                                           orderby m.City
                                           select m.City;

            var hotel = from m in _context.Hotels
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                hotel = hotel.Where(s => s.Name!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(hotelCity))
            {
                hotel = hotel.Where(x => x.City == hotelCity);
            }

            var hotelCityVM = new HotelCityViewModel
            {
                City = new SelectList(await cityQuery.Distinct().ToListAsync()),
                Hotels = await hotel.ToListAsync()
            };
            return View(hotelCityVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotels == null)
            {
                return NotFound();
            }

            return View(hotels);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City,Price,Stars")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotels);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }
            return View(hotels);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Price,Stars")] Hotels hotels)
        {
            if (id != hotels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelsExists(hotels.Id))
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
            return View(hotels);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotels == null)
            {
                return NotFound();
            }

            return View(hotels);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'MDSProjectContext.Hotels'  is null.");
            }
            var hotels = await _context.Hotels.FindAsync(id);
            if (hotels != null)
            {
                _context.Hotels.Remove(hotels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelsExists(int id)
        {
          return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
