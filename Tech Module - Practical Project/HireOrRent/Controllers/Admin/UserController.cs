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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace HireOrRent.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            var users = db.Users.OrderBy(u => u.FullName).ToList();

            var admins = GetAdminUserNames(users, db);

            ViewBag.Admins = admins;

            return View(users);
        }

        // GET: User/Details/id
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var applicationUser = db.Users.Find(id);

            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            return View(applicationUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: User/Edit/id
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var model = new EditUserViewModel();
            model.User = user;
            model.Roles = GetUserRoles(user, db);

            return View(model);
        }

        // POST: User/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.First(u => u.Id == id);

                if (!string.IsNullOrEmpty(model.Password))
                {
                    var hasher = new PasswordHasher();
                    var passwordHash = hasher.HashPassword(model.Password);
                    user.PasswordHash = passwordHash;
                }

                user.Email = model.User.Email;
                user.UserName = model.User.Email;
                user.FullName = model.User.FullName;
                this.SetUserRoles(model, user, db);


                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: User/Delete/id
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: User/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var user = db.Users.Find(id);

            var userAdvertisements = db.Advertisements.Where(a => a.Author.Id == user.Id).ToList();

            foreach (var advertisement in userAdvertisements)
            {
                db.Advertisements.Remove(advertisement);
            }

            var userComments = db.Comments.Where(a => a.Author.Id == user.Id).ToList();

            foreach (var comment in userComments)
            {
                db.Comments.Remove(comment);
            }

            db.Users.Remove(user);
            db.SaveChanges();

            this.AddNotification("User Deleted!", NotificationType.INFO);
            return RedirectToAction("Index");
        }

        private HashSet<string> GetAdminUserNames(List<ApplicationUser> users, ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var admins = new HashSet<string>();

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            return admins;
        }

        private List<Role> GetUserRoles(ApplicationUser user, ApplicationDbContext db)
        {
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var roles = db.Roles.Select(r => r.Name).OrderBy(r => r).ToList();

            var userRoles = new List<Role>();

            foreach (var roleName in roles)
            {
                var role = new Role { Name = roleName };

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.IsSelected = true;
                }

                userRoles.Add(role);
            }

            return userRoles;
        }

        private void SetUserRoles(EditUserViewModel model, ApplicationUser user, ApplicationDbContext context)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            foreach (var role in model.Roles)
            {
                if (role.IsSelected)
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if (!role.IsSelected)
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
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
