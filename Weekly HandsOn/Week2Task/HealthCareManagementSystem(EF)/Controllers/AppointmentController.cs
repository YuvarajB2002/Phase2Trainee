using HealthCareManagementSystem_EF_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem_EF_.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HealthcareManagementSystemContext _context;
        // GET: AppointmentController
        public AppointmentController(HealthcareManagementSystemContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Appointments.Include(c => c.Patient).ToList());
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            Appointment a= _context.Appointments.Include(c => c.Patient).FirstOrDefault(o => o.PatientId == id) ?? new Appointment();
            return View(a);
           
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name");
            return View();
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment a)
        {
            try
            {
                ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name", a.PatientId);
                _context.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name");
            Appointment a = _context.Appointments.Include(c => c.Patient).FirstOrDefault(o => o.PatientId == id) ?? new Appointment();
            return View(a);

        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Appointment a)
        {
            try
            {
                ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name", a.PatientId);
                _context.Update(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            Appointment a = _context.Appointments.Include(c => c.Patient).FirstOrDefault(o => o.PatientId == id) ?? new Appointment();
            return View(a);
  
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Appointment a)
        {
            try
            {
                _context.Remove(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
