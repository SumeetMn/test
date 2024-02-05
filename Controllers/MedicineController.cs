using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicineTrackingSystem.Models;


namespace MedicineTrackingSystem.Controllers
{
    public class MedicineController : Controller
    {
        private static List<Medicine> medicines = new List<Medicine>();
        // GET: Medicine
        public ActionResult Index()
        {
            return View(medicines);
        }
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var searchResults = medicines.Where(m => m.FullName.Contains(searchTerm)).ToList();
            return PartialView("Search", searchResults);
        }

        public ActionResult Details(int id)
        {
            var medicine = medicines.FirstOrDefault(m => m.Id == id);
            return View(medicine);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Medicine medicine)
        {
            // Validate expiry date
            if (medicine.ExpiryDate < DateTime.Now.AddDays(15))
            {
                ModelState.AddModelError("ExpiryDate", "Expiry date should be minimum 15 days from today.");
            }

            if (ModelState.IsValid)
            {
                medicine.Id = medicines.Count + 1;
                medicines.Add(medicine);
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

    }
}