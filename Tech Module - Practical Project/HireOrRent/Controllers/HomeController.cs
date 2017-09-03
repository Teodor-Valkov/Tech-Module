using HireOrRent.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HireOrRent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var categories = db.Categories.Include(c => c.Advertisements).OrderBy(c => c.Id).ToList();

                return View(categories);
            }
        }

        public ActionResult CategoryAdvertisements(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new ApplicationDbContext())
            {
                var categoryName = db.Categories.Find(categoryId).Name;

                if (categoryName == "Hire")
                {
                    ViewBag.Category = "Hire";
                }
                else
                {
                    ViewBag.Category = "Rent";
                }

                var advertisements = db.Advertisements.Where(a => a.CategoryId == categoryId).Include(a => a.Author).OrderBy(a => a.DateAdded).ToList();

                return View(advertisements);
            }
        }
    }
}