using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers
{
    public class DoctorController : Controller
    {
        // GET: DoctorController
        public ActionResult Index()
        {
            var doctors = Data.Doctors.Select(d => d.ToReadVM()).ToList();
            return View(doctors);
        }

        public ActionResult Details(int id)
        {
            var doc = Data.Doctors.Single(d => d.Id == id).ToReadVM();
            return View(doc);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(DoctorCreateVM input)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var doc = input.ToModel();
            doc.Id = Data.Doctors.Max(d => d.Id) + 1;
            Data.Doctors.Add(doc);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var doc = Data.Doctors.Single(d => d.Id == id);
            Data.Doctors.Remove(doc);

            return NoContent();
        }

        public ActionResult Update(int id)
        {
            var doc = Data.Doctors.Single(d => d.Id == id).ToUpdateVM();
            return View(doc);
        }


        [HttpPost]
        public ActionResult Update(int id, DoctorUpdateVM input)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            var doc = Data.Doctors.Single(d => d.Id == id);
            input.ToModel(doc);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
