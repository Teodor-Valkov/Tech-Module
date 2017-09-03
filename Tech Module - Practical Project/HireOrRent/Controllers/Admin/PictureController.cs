using HireOrRent.Models;
using System.Linq;
using System.Web.Mvc;

namespace HireOrRent.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PictureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Picture
        public ActionResult Index()
        {
            var pictures = db.Pictures.ToList();

            return View(pictures);
        }

        public ActionResult Upload()
        {
            return View();
        }

        // POST: Picture/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(Picture picture)
        {
            if (picture.File == null)
            {
                return View();
            }

            if (picture.File.ContentLength > (2 * 1024 * 1024))
            {
                ViewBag.Error = "File size must be less than 2 MB";
                return View();
            }

            if (picture.File.ContentType != "image/jpeg" && picture.File.ContentType != "image/gif")
            {
                ViewBag.Error = "File type allowed : jpeg and gif";
                return View();
            }

            picture.Name = picture.File.FileName;
            picture.PictureSize = picture.File.ContentLength;

            picture.PictureData = new byte[picture.File.ContentLength];
            picture.File.InputStream.Read(picture.PictureData, 0, picture.File.ContentLength);

            db.Pictures.Add(picture);
            db.SaveChanges();

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