using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // Get: User/List
        public ActionResult List()
        {
            using (var db = new BlogDbContext())
            {
                var users = db.Users.ToList();

                var admins = GetAdminUserNames(users, db);

                ViewBag.Admins = admins;

                return View(users);
            }
        }

        //
        // Get: User/Edit
        public ActionResult Edit(string id)
        {
            // Validate id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }

            using (var db = new BlogDbContext())
            {
                // Get user from database
                var user = db.Users.First(u => u.Id == id);

                // Check if user exists
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Create a view model
                var viewModel = new EditUserViewModel();
                viewModel.User = user;
                viewModel.Roles = GetUserRoles(user, db);

                // Pass the model to the view
                return View(viewModel);
            }
        }

        //
        //Post: User/Edit
        [HttpPost]
        public ActionResult Edit(string id, EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    // Get user from database
                    var user = db.Users.FirstOrDefault(u => u.Id == id);

                    // Check if user exists
                    if (user == null)
                    {
                        return HttpNotFound();
                    }

                    // Check if password field is filled and if it's not empty, change the password
                    if (!string.IsNullOrEmpty(viewModel.Password))
                    {
                        var hasher = new PasswordHasher();
                        var passwordHash = hasher.HashPassword(viewModel.Password);
                        user.PasswordHash = passwordHash;
                    }

                    // Set user properties
                    user.Email = viewModel.User.Email;
                    user.UserName = viewModel.User.Email;
                    user.FullName = viewModel.User.FullName;
                    this.SetUserRoles(viewModel, user, db);

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("List");
                }
            }

            return View(viewModel);
        }

        //
        // Get: User/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                // Get user from database
                var user = db.Users.FirstOrDefault(u => u.Id.Equals(id));

                // Check if user exists 
                if (user == null)
                {
                    return HttpNotFound();
                }

                return View(user);
            }
        }

        //
        // Post: User/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                // Get user from database
                var user = db.Users.FirstOrDefault(u => u.Id == id);

                // Get user articles from database 
                var userArticles = db.Articles.Where(a => a.Author.Id == user.Id);

                // Delete user articles from database 
                foreach (var article in userArticles)
                {
                    db.Articles.Remove(article);
                }

                // Delete user from database and save changes
                db.Users.Remove(user);
                db.SaveChanges();

                return RedirectToAction("List");
            }
        }

        private void SetUserRoles(EditUserViewModel viewModel, ApplicationUser user, BlogDbContext context)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            foreach (var role in viewModel.Roles)
            {
                if (role.isSelected && !userManager.IsInRole(user.Id, role.Name))
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if (!role.isSelected && userManager.IsInRole(user.Id, role.Name))
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
        }

        private HashSet<string> GetAdminUserNames(List<ApplicationUser> users, BlogDbContext context)
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

        private List<Role> GetUserRoles(ApplicationUser user, BlogDbContext db)
        {
            // Create user manager 
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // Get all application roles
            var roles = db.Roles.Select(r => r.Name).OrderBy(r => r).ToList();

            // For each application role, check if the user has it
            var userRoles = new List<Role>();

            foreach (var roleName in roles)
            {
                var role = new Role {Name = roleName};

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.isSelected = true;
                }

                userRoles.Add(role);
            }

            // Return a list with all roles which the user has
            return userRoles;
        }
    }
}