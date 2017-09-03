using HireOrRent.Extensions;
using HireOrRent.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HireOrRent.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: City
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var cities = db.Cities.OrderBy(c => c.Id).ToList();

                return View(cities);
            }
        }

        //GET: Ciry/Details/id
        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var users = db.Users.Where(u => u.CityId == id).ToList();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                ViewBag.Admins = users.Where(u => userManager.IsInRole(u.Id, "Admin")).ToList();

                ViewBag.CityName = db.Cities.FirstOrDefault(t => t.Id == id).Name;

                return View(users);
            }
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();

                this.AddNotification("City Created!", NotificationType.INFO);
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: City/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var city = db.Cities.FirstOrDefault(c => c.Id == id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // POST: City/Edit/id
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();

                this.AddNotification("City Edited!", NotificationType.INFO);
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: City/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var city = db.Cities.FirstOrDefault(c => c.Id == id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // POST: City/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var city = db.Cities.Find(id);

            var cityUsers = city.Users.ToList();

            foreach (var user in cityUsers)
            {
                var userAdvertisements = db.Advertisements.Where(a => a.AuthorId == user.Id).ToList();

                foreach (var advertisement in userAdvertisements)
                {
                    db.Advertisements.Remove(advertisement);
                }

                var userComments = db.Comments.Where(a => a.AuthorId == user.Id).ToList();

                foreach (var comment in userComments)
                {
                    db.Comments.Remove(comment);
                }

                db.Users.Remove(user);
            }

            db.Cities.Remove(city);
            db.SaveChanges();

            this.AddNotification("City Deleted!", NotificationType.INFO);
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