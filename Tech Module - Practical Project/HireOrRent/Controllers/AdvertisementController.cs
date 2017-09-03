using HireOrRent.Extensions;
using HireOrRent.Models;
using HireOrRent.ModelsView;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HireOrRent.Controllers
{
    public class AdvertisementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Advertisement
        public ActionResult Index()
        {
            var advertisements = db.Advertisements.Include(a => a.Author).OrderBy(a => a.DateAdded).ToList();

            return View(advertisements);
        }

        // GET: Advertisement/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var advertisement = db.Advertisements.Where(a => a.Id == id).Include(a => a.Author).Include(a => a.Comments).First();

            if (advertisement == null)
            {
                return HttpNotFound();
            }

            return View(advertisement);
        }

        // GET: Advertisement/Search
        public ActionResult Search(string searchString)
        {
            var advertisements = db.Advertisements.OrderBy(a => a.DateAdded).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                advertisements = db.Advertisements.Where(a => a.Title.Contains(searchString)).OrderBy(a => a.DateAdded).ToList();
            }

            return View(advertisements);
        }

        // GET: Advertisement/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new AdvertisementViewModel();
            model.Categories = db.Categories.OrderBy(c => c.Name).ToList();
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");

            return View(model);
        }

        // POST: Advertisement/Create
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,DateAdded,AuthorId,CategoryId")] AdvertisementViewModel model, HttpPostedFileBase pictureBase)
        {
            if (ModelState.IsValid)
            {
                var authorId = db.Users.First(u => u.UserName == this.User.Identity.Name).Id;

                var advertisement = new Advertisement(authorId, model.Title, model.Content, model.CategoryId);

                if (pictureBase != null)
                {
                    advertisement.Picture = new byte[pictureBase.ContentLength];
                    pictureBase.InputStream.Read(advertisement.Picture, 0, pictureBase.ContentLength);
                }

                db.Advertisements.Add(advertisement);
                db.SaveChanges();

                this.AddNotification("Advertisement Created!", NotificationType.INFO);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Advertisement/Edit/id
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var advertisement = db.Advertisements.FirstOrDefault(c => c.Id == id);

            if (advertisement == null)
            {
                return HttpNotFound();
            }

            if (!IsUserAuthorizedToEdit(advertisement))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var model = new AdvertisementViewModel();
            model.Id = advertisement.Id;
            model.Title = advertisement.Title;
            model.Content = advertisement.Content;
            model.CategoryId = advertisement.CategoryId;
            model.Categories = db.Categories.OrderBy(c => c.Name).ToList();

            return View(model);
        }

        // POST: Advertisement/Edit/id
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,DateAdded,AuthorId,CategoryId")] AdvertisementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var advertisement = db.Advertisements.First(a => a.Id == model.Id);

                advertisement.Title = model.Title;
                advertisement.Content = model.Content;
                advertisement.DateAdded = DateTime.Now;
                advertisement.CategoryId = model.CategoryId;

                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();

                this.AddNotification("Advertisement Edited!", NotificationType.INFO);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Advertisement/Delete/id
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var advertisement = db.Advertisements.FirstOrDefault(c => c.Id == id);

            if (advertisement == null)
            {
                return HttpNotFound();
            }

            if (!IsUserAuthorizedToEdit(advertisement))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(advertisement);
        }

        // POST: Advertisement/Delete/id
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var advertisement = db.Advertisements.Find(id);

            db.Advertisements.Remove(advertisement);
            db.SaveChanges();

            this.AddNotification("Advertisement Deleted!", NotificationType.INFO);
            return RedirectToAction("Index");
        }

        private bool IsUserAuthorizedToEdit(Advertisement advertisement)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = advertisement.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
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