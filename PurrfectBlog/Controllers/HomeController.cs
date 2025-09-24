using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PurrfectBlog.Models;

namespace PurrfectBlog.Controllers
{
    public class HomeController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        public ActionResult Index()
        {
            var recentPosts = db.BlogPosts.OrderByDescending(p => p.CreatedAt).Take(3).ToList();

            return View(recentPosts);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}