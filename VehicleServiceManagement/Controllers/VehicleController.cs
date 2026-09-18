using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManagement.Data;
using VehicleServiceManagement.Models;

namespace VehicleServiceManagement.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vehicles = _context.Vehicles
                .Include(v => v.Customer)
                .ToList();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(
                  _context.Customers.ToList(),
                  "CustomerId",
                  "Name"
            );

            return View();

        }

        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                

                ViewBag.Customers = new SelectList(
                    _context.Customers.ToList(),
                    "CustomerId",
                    "Name",
                    vehicle.CustomerId
                );

                return View(vehicle);
            }
            _context.Vehicles.Add(vehicle);

            _context.SaveChanges();

            TempData["Success"] = "Vehicle added successfully!";

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Vehicle = _context.Vehicles.Find(id);

            if (Vehicle == null)
            {
                return NotFound();
            }

            ViewBag.Customers = new SelectList(
               _context.Customers.ToList(),
               "CustomerId",
               "Name",
               Vehicle.CustomerId
           );


            return View(Vehicle);
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);

            _context.SaveChanges();

            TempData["Success"] = "vehicle updated successfully!";

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);

            _context.SaveChanges();

            TempData["Success"] = "Customer deleted successfully!";

            return RedirectToAction("Index");
        }



    }
}
