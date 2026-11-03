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

    }
}
