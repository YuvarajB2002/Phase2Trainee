using HealthCareManagementSystem_EF_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem_EF_.Controllers
{
    public class TreatmentPlanController : Controller
    {
        private readonly HealthcareManagementSystemContext _context;
        public TreatmentPlanController(HealthcareManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.TreatmentPlans.Include(c => c.Patient).ToList());
        }
        public ActionResult Details(int id)
        {
            TreatmentPlan t = _context.TreatmentPlans.Include(c => c.Patient).FirstOrDefault(o => o.PatientId == id) ?? new TreatmentPlan();
            return View(t);

        }

        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentPlan t)
        {
            try
            {
                ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name", t.PatientId);
                _context.Add(t);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name");
            TreatmentPlan t = _context.TreatmentPlans.Include(c => c.Patient).FirstOrDefault(o => o.PatientId == id) ?? new TreatmentPlan();
            return View(t);

        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TreatmentPlan t)
        {
            try
            {
                ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "Name", t.PatientId);
                _context.Update(t);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            TreatmentPlan t = _context.TreatmentPlans.Include(c => c.Patient).FirstOrDefault(o => o.PatientId == id) ?? new TreatmentPlan();
            return View(t);

        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TreatmentPlan t)
        {
            try
            {
                _context.Remove(t);
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
