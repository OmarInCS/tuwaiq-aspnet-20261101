using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ClinicContext _db;

        public DoctorController(ClinicContext db)
        {
            _db = db;
        }


        // GET: DoctorController
        public ActionResult Index()
        {
            var doctors = _db.Doctors.Select(d => d.ToReadVM()).ToList();
            return View(doctors);
        }

        public ActionResult Details(int id)
        {
            var doc = _db.Doctors.Single(d => d.Id == id).ToReadVM();
            return View(doc);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorCreateVM input)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var doc = input.ToModel();
            _db.Doctors.Add(doc);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var doc = _db.Doctors.Single(d => d.Id == id);
            _db.Doctors.Remove(doc);
            _db.SaveChanges();

            return NoContent();
        }

        public ActionResult Update(int id)
        {
            var doc = _db.Doctors.Single(d => d.Id == id).ToUpdateVM();
            return View(doc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, DoctorUpdateVM input)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            var doc = _db.Doctors.Single(d => d.Id == id);
            input.ToModel(doc);
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
