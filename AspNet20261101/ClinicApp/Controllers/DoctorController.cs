using ClinicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers
{
    public class DoctorController : Controller
    {
        // GET: DoctorController
        public ActionResult Index()
        {
            return View(Data.Doctors);
        }

        public ActionResult Details(int id)
        {
            var doc = Data.Doctors.Single(d => d.Id == id);
            return View(doc);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Doctor input)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            input.Id = Data.Doctors.Max(d => d.Id) + 1;
            Data.Doctors.Add(input);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var doc = Data.Doctors.Single(d => d.Id == id);
            Data.Doctors.Remove(doc);

            return RedirectToAction(nameof(Index));
        }
    }
}
