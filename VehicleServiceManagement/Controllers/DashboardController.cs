using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManagement.Data;

namespace VehicleServiceManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TotalCustomers = _context.Customers.Count();

            ViewBag.TotalVehicles = _context.Vehicles.Count();

            ViewBag.TotalServices = _context.ServiceRecords.Count();

            ViewBag.RecentServices = _context.ServiceRecords
                .Include(s => s.Vehicle)
                .OrderByDescending(s => s.ServiceDate)
                .Take(5)
                .ToList();

            ViewBag.LatestCustomers = _context.Customers
                .OrderByDescending(c => c.CustomerId)
                .Take(5)
                .ToList();

            ViewBag.LatestVehicles = _context.Vehicles
                .Include(v => v.Customer)
                .OrderByDescending(v => v.VehicleId)
                .Take(5)
                .ToList();


            return View();
        }


    }
}
