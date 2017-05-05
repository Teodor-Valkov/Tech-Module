using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.Ajax.Utilities;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // Get: Article/List
        public ActionResult List()
        {
            using (var db = new BlogDbContext())
            {
                //Get articles from database
                var articles = db.Articles
                    .Include(a => a.Author)
                    .Include(a => a.Tags)
                    .ToList();

                return View(articles);
            }
        }

        //
        // Get: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                // Get the article from database
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .Include(a => a.Tags)
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }

        //
        // Get: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            using (var db = new BlogDbContext())
            {
                var model = new ArticleViewModel();
                model.Categories = db.Categories.OrderBy(c => c.Name).ToList();

                return View(model);
            }
        }

        //
        // Post: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    // Get authorId
                    var authorId = db.Users.First(u => u.UserName == this.User.Identity.Name).Id;

                    // Use the constructor to create the article
                    var article = new Article(authorId, model.Title, model.Content, model.CategoryId);

                    this.SetArticleTags(article, model, db);

                    // Save article in database
                    db.Articles.Add(article);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        //
        // Get: Article/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                // Get article from database
                var article = db.Articles.FirstOrDefault(a => a.Id == id);
                
                // Check if article exist
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Create the view model
                var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;
                model.CategoryId = article.CategoryId;
                model.Categories = db.Categories.OrderBy(c => c.Name).ToList();
                model.Tags = string.Join(", ", article.Tags.Select(t => t.Name));

                // Pass the view model to the view
                return View(model);
            }
        }

        //
        // Post: Article/Edit
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            //Check if model state is valid 
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    // Get article from database
                    var article = db.Articles.FirstOrDefault(a => a.Id == model.Id);

                    // Check if current user is authorized to edit the article
                    if (!IsUserAuthorizedToEdit(article))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                    }

                    // Set article properties
                    article.Title = model.Title;
                    article.Content = model.Content;
                    article.CategoryId = model.CategoryId;
                    this.SetArticleTags(article, model, db);

                    // Save article state in database
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();

                    // Redirect to index
                    return RedirectToAction("Index");
                }
            }

            // If model state is invalid return the same view
            return View(model);
        }

        //
        // Get: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                // Get article from database
                var article = db.Articles.Where(a => a.Id == id).Include(a => a.Author).Include(a => a.Category).First();

                ViewBag.TagsString = string.Join(", ", article.Tags.Select(t => t.Name));

                // Check if article exist
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Pass the view model to the view
                return View(article);
            }
        }

        //
        // Post: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                // Get article from database
                var article = db.Articles.Where(a => a.Id == id).Include(a => a.Author).Include(a => a.Category).First();
               
                // Check if current user is authorized to delete the article
                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                // Check if article exist
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Set article properties
                article.Title = article.Title;
                article.Content = article.Content;
                article.CategoryId = article.CategoryId;

                // Delete the article from database
                db.Articles.Remove(article);
                db.SaveChanges();

                // Redirect to index
                return RedirectToAction("Index");
            }
        }

        //
        // A method to check if the current user is Admin or Author in order to edit the article
        public bool IsUserAuthorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }

        private void SetArticleTags(Article article, ArticleViewModel model, BlogDbContext db)
        {
            // Split tags
            var tagsString = model.Tags.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(t => t.ToLower()).Distinct();

            // Clear current article tags
            article.Tags.Clear();

            // Set new article tags
            foreach (var tagString in tagsString)
            {
                // Get tag from database by its name
                Tag tag = db.Tags.FirstOrDefault(t => t.Name.Equals(tagString));

                // If the tag is null, create new tag
                if (tag == null)
                {
                    tag = new Tag() { Name = tagString };
                    db.Tags.Add(tag);
                }

                // Add the tag to article tags
                article.Tags.Add(tag);
            }
        }
    }
}