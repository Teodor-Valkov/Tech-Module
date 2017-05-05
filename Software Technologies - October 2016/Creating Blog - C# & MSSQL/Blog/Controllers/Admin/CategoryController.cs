﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers.Admin
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // GET: Category/List
        public ActionResult List()
        {
            using (var db = new BlogDbContext())
            {
                var categories = db.Categories.ToList();

                return View(categories);
            }
        }

        //
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    db.Categories.Add(category);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        //
        // GET: Category/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    return HttpNotFound();
                }

                return View(category);
            }
        }

        //
        // POST: Category/Edit
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        //
        // GET: Category/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    return HttpNotFound();
                }

                return View(category);
            }
        }

        //
        // POST: Category/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            using (var db = new BlogDbContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == id);

                var categoryArticles = category.Articles.ToList();

                foreach (var article in categoryArticles)
                {
                    db.Articles.Remove(article);
                }

                db.Categories.Remove(category);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}