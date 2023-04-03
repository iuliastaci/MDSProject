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
    public class FlightsController : Controller
    {
        private readonly MDSProjectContext _context;

        public FlightsController(MDSProjectContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index(string searchString, string flightAirline)
        {
            if (_context.Flights == null)
            {
                return Problem("Entity set 'MDSProjectContext.Flights'  is null.");
            }

            IQueryable<string> airlineQuery = from m in _context.Flights
                                              orderby m.Airline
                                              select m.Airline;

            var flight = from m in _context.Flights
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                flight = flight.Where(s => s.Departure_Airport!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(flightAirline))
            {
                flight = flight.Where(x => x.Airline == flightAirline);
            }

            var flightAirlineVM = new FlightAirlineViewModel
            {
                Airline = new SelectList (await airlineQuery.Distinct().ToListAsync()),
                Flights = await flight.ToListAsync()
            };

            return View(flightAirlineVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Airline,Departure_Airport,Arrival_Airport,Flight_Time,Price")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flights);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights.FindAsync(id);
            if (flights == null)
            {
                return NotFound();
            }
            return View(flights);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Airline,Departure_Airport,Arrival_Airport,Flight_Time,Price")] Flights flights)
        {
            if (id != flights.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightsExists(flights.Id))
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
            return View(flights);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flights == null)
            {
                return Problem("Entity set 'MDSProjectContext.Flights'  is null.");
            }
            var flights = await _context.Flights.FindAsync(id);
            if (flights != null)
            {
                _context.Flights.Remove(flights);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightsExists(int id)
        {
          return (_context.Flights?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
