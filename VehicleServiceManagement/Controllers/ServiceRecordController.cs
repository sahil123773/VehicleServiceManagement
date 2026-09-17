using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManagement.Data;
using VehicleServiceManagement.Models;

namespace VehicleServiceManagement.Controllers
{

    public class ServiceRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRecordController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var services = _context.ServiceRecords
                .Include(s=>s.Vehicle)
                .ToList();

            return View(services);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(
                  _context.Vehicles.ToList(),
                  "VehicleId",
                  "VehicleNumber"
            );

            return View();

        }

        [HttpPost]
        public IActionResult Create(ServiceRecord serviceRecord)
        {
            _context.ServiceRecords.Add(serviceRecord);

            _context.SaveChanges();

            TempData["Success"] = "Service record added successfully!";

            return RedirectToAction("Index");
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            var Service = _context.ServiceRecords.Find(id);

            if(Service == null)
            {
                return NotFound();

            }
            ViewBag.Vehicles = new SelectList(
                  _context.Vehicles.ToList(),
                  "VehicleId",
                  "VehicleNumber",
                  Service.VehicleId
            );

            return View(Service);


        }

        [HttpPost]
        public IActionResult Edit(ServiceRecord serviceRecord)
        {
            _context.ServiceRecords.Update(serviceRecord);

            _context.SaveChanges();

            TempData["Success"] = "service updated successfully!";

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var service = _context.ServiceRecords.Find(id);

            if (service == null)
            {
                return NotFound();
            }

            _context.ServiceRecords.Remove(service);

            _context.SaveChanges();

            TempData["Success"] = "Service deleted successfully!";

            return RedirectToAction("Index");
        }

    }
}
