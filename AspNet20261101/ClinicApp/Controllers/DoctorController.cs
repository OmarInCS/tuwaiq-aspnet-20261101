using ClinicApp.Helpers;
using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly ClinicContext _db;

        public DoctorController(ClinicContext db, DoctorService docService, OtherService otherService)
        {
            _db = db;
        }


        // GET: DoctorController
        public ActionResult Index(DoctorQueryVM query)
        {

            var initQuery = _db.Doctors
                            .Where(d => query.Name == null || d.Name.Contains(query.Name))
                            .Where(d => query.Id == null || d.Id == query.Id)
                            .Where(d => query.HireDateStart == null || d.HireDate >= query.HireDateStart)
                            .Where(d => query.HireDateEnd == null || d.HireDate <= query.HireDateEnd);

            query.TotalRows = initQuery.Count();

            var doctors = initQuery
                            .Skip(query.PreviousRows)
                            .Take(query.PageSize)
                            .Select(d => d.ToReadVM())
                            .ToList();

            var vm = new DoctorFilteredListVM { Doctors = doctors, Query = query };
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var doc = _db.Doctors
                        .Include(d => d.Speciality)
                        .Single(d => d.Id == id)
                        .ToReadVM();
            return View(doc);
        }

        public ActionResult Create()
        {
            var vm = new DoctorCreateVM();
            vm.AllSpecialities = _db.Specialities.Select(s => s.ToReadVM()).ToList();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorCreateVM input)
        {

            if (!ModelState.IsValid)
            {
                var vm = new DoctorCreateVM();
                vm.AllSpecialities = _db.Specialities.Select(s => s.ToReadVM()).ToList();
                return View(vm);
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
            doc.AllSpecialities = _db.Specialities.Select(s => s.ToReadVM()).ToList();
            return View(doc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, DoctorUpdateVM input)
        {

            if (!ModelState.IsValid)
            {
                var vm = _db.Doctors.Single(d => d.Id == id).ToUpdateVM();
                vm.AllSpecialities = _db.Specialities.Select(s => s.ToReadVM()).ToList();
                return View(vm);
            }


            var doc = _db.Doctors.Single(d => d.Id == id);
            input.ToModel(doc);
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
