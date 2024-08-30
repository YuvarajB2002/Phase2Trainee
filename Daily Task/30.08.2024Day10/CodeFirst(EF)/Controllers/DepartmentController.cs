using EFCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentDbContext _context;
        public DepartmentController(StudentDbContext context)
        {
            _context = context;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(_context.Departments.Include(c => c.Student).ToList());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            Department d=_context.Departments.Include(c => c.Student).FirstOrDefault(o => o.DepartmentId == id)?? new Department();
            return View(d);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department d)
        {
            try
            {
                ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "StudentName",d.StudentId);
                _context.Add(d);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "StudentName");
            Department d = _context.Departments.Include(c => c.Student).FirstOrDefault(o => o.DepartmentId == id) ?? new Department();
            return View(d);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department d)
        {
            try
            {
                ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "StudentName", d.StudentId);
                _context.Update(d);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            Department d = _context.Departments.Include(c => c.Student).FirstOrDefault(o => o.DepartmentId == id) ?? new Department();
            return View(d);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Department d)
        {
            try
            {
                _context.Remove(d);
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
