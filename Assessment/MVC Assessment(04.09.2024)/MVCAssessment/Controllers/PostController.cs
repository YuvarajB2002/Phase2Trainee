using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController

        private readonly IPost _post;
        private readonly IUser _user;
        public PostController(IPost post, IUser user)
        {
            _post = post;
            _user = user;
        }
        public ActionResult Index()
        {
            IEnumerable<Post> p = _post.GetAll();
            return View(p);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            Post r = _post.GetPost(id);
            return View(r);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_user.GetAll(), "uId", "Username");
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post p)
        {
            try
            {
                ViewBag.UserId = new SelectList(_user.GetAll(), "uId", "Username", p.UserId);
                _post.AddPost(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.UserId = new SelectList(_user.GetAll(), "uId", "Username");
            Post r = _post.GetPost(id);
            return View(r);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post p)
        {
            try
            {
                _post.UpdatePost(id,p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            Post r = _post.GetPost(id);
            return View(r);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post p)
        {
            try
            {
                _post.DeletePost(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
