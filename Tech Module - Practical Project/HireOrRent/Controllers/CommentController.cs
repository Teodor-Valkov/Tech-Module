using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HireOrRent.Extensions;
using HireOrRent.Models;
using HireOrRent.ModelsView;
using Microsoft.AspNet.Identity;

namespace HireOrRent.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comment/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new CommentViewModel();

            ViewBag.AdvertisementId = id;
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,AdvertisementId,AuthorId")] int? id, CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authorId = db.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name).Id;

                var advertisementId = db.Advertisements.Find(id).Id;

                var comment = new Comment(model.Content, authorId, advertisementId);

                db.Comments.Add(comment);
                db.SaveChanges();

                this.AddNotification("Comment Created!", NotificationType.INFO);
                return RedirectToAction("Index", "Advertisement");
            }

            return View(model);
        }

        // GET: Comment/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = db.Comments.Where(c => c.Id == id).Include(c => c.Author).FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            if (!IsUserAuthorizedToEdit(comment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var model = new CommentViewModel();
            model.Content = comment.Content;

            ViewBag.AdvertisementId = comment.AdvertisementId;
            return View(model);
        }

        // POST: Comment/Edit/id
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,AdvertisementId,AuthorId")] CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = db.Comments.Find(model.Id);

                comment.Content = model.Content;

                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();

                this.AddNotification("Comment Edited!", NotificationType.INFO);
                return RedirectToAction("Index", "Advertisement");
            }

            return View(model);
        }

        // GET: Comment/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = db.Comments.FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            if (!IsUserAuthorizedToEdit(comment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(comment);
        }

        // POST: Comment/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = db.Comments.Find(id);

            db.Comments.Remove(comment);
            db.SaveChanges();

            this.AddNotification("Comment Deleted!", NotificationType.INFO);
            return RedirectToAction("Index", "Advertisement");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // A method to check if the current user is Admin or Author in order to edit the article
        public bool IsUserAuthorizedToEdit(Comment comment)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = comment.IsAuthor(this.User.Identity.GetUserId());

            return isAdmin || isAuthor;
        }
    }
}
