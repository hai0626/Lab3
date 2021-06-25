using Lab3.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class BookController : Controller
    {
        BookDBContext db = new BookDBContext();
        // GET: Book
        [Authorize]
        public ActionResult ListBook()
        {
            BookDBContext db = new BookDBContext();
            var listBook = db.Books.ToList();
            return View(listBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            BookDBContext db = new BookDBContext();
            Book book = db.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book b)
        {
            db.Books.AddOrUpdate(b);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Book b = db.Books.SingleOrDefault(p => p.ID == id);
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book b)
        {
            Book dbUpdate = db.Books.SingleOrDefault(p => p.ID == b.ID);
            if(dbUpdate != null){
                db.Books.AddOrUpdate(b);
                db.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.SingleOrDefault(p => p.ID == id);
            return View(b);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book b)
        {
            Book dbDelete = db.Books.SingleOrDefault(p => p.ID == b.ID);
            if (dbDelete != null)
            {
                db.Books.Remove(dbDelete);
                db.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }

    }
}