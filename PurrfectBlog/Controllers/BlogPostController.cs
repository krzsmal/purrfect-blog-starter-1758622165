using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PurrfectBlog.Models;

namespace PurrfectBlog.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        // GET: BlogPost
        public ActionResult Index()
        {
            var posts = db.BlogPosts.OrderByDescending(p => p.CreatedAt).ToList();
            return View(posts);
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            return View(blogPost);
        }

        // GET: BlogPost/CreatePost
        public ActionResult CreatePost()
        {
            return View();
        }

        // POST: BlogPost/CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Include = "Title,Content,Category")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.CreatedAt = DateTime.Now;
                db.BlogPosts.Add(blogPost);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Your blog post has been created successfully!";
                return RedirectToAction("Details", new { id = blogPost.Id });
            }

            return View(blogPost);
        }

        // GET: BlogPost/EditPost/5
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            return View(blogPost);
        }

        // POST: BlogPost/EditPost/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "Id,Title,Content,Category,CreatedAt")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Your blog post has been updated successfully!";
                return RedirectToAction("Details", new { id = blogPost.Id });
            }

            return View(blogPost);
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            db.BlogPosts.Remove(blogPost);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Blog post has been deleted successfully!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}