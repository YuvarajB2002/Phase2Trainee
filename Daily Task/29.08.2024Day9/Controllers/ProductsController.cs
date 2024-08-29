using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCADO.DataAccess;
using MVCADO.Models;

namespace MVCADO.Controllers
{
    public class ProductsController : Controller
    {
        ProductDataAccess pda=new ProductDataAccess();
        // GET: ProductsController
        public IActionResult Index()
        {
            List<Product> li = ProductDataAccess.Fetch();
            return View(li);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            Product p = ProductDataAccess.Search(id); 
            return View(p);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                Product p2=ProductDataAccess.Insert(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = ProductDataAccess.Search(id);
            return View(p);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Product p)
        {
            try
            {
                ProductDataAccess.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = ProductDataAccess.Search(id);
            return View(p);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                ProductDataAccess.Delete(id,p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
