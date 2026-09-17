using Microsoft.AspNetCore.Mvc;
using VehicleServiceManagement.Data;
using VehicleServiceManagement.Models;

namespace VehicleServiceManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _context.Customers.Add(customer);
            
         _context.SaveChanges();
         TempData["Success"] = "Customer added successfully!";

         return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Customers.Update(customer);

            _context.SaveChanges();

            TempData["Success"] = "Customer updated successfully!";

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);

            _context.SaveChanges();

            TempData["Success"] = "Customer deleted successfully!";

            return RedirectToAction("Index");
        }


    }
}
