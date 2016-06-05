using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Search_Task.Models;
using TestSearchTask.Models;

namespace Test_Search_Task.Controllers
{
    [RoutePrefix("Books")]
    [Route("{action}")]
    public class BooksController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: Books
        [Route("~/")]           // http://localhost:xxxxx/
        [Route]                 //http://localhost:xxxxx/Books/
        [Route("index")]
        [Route("bookslist")]    //http://localhost:xxxxx/Books/BooksList.
        //public ActionResult Index()
        //{
        //    return View(db.Books.ToList());
        //}

        public ActionResult Index(string searchString)
        {
            var books = from b in db.Books
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {

            RetrieveGenreList();

            return View(new Book());
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,NewReleaseComingSoon,NewReleaseWithinPastMonth,Genre,Price")] Book book)
        {
            // Validating Date type fields - start
            bool ValidationResults = true;
            if (book.ReleaseDate != DateTime.Today)
            {
                ModelState.AddModelError("", "'Release Date' must be today date.");
                ValidationResults = false;
            }

            DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);
            if (book.NewReleaseWithinPastMonth < thirtyDaysAgo || book.NewReleaseWithinPastMonth > DateTime.Today)
            {
                ModelState.AddModelError("", "'New Release: Last 30 Days' must be within the past 30 days.");
                ValidationResults = false;
            }
            // Validating Date type fields - end

            if (ModelState.IsValid && ValidationResults)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                book.GenreList = RetrieveGenreList();
                return View(book);
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            book.GenreList = RetrieveGenreList();
            ViewBag.bookGenre = new SelectList(book.GenreList, book.Genre);


            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,NewReleaseComingSoon,NewReleaseWithinPastMonth,Genre,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // returns list of book's genres from the db. its being used by the BookPicker
        //private List<string> RetrieveGenreList()
        //{
        //    var GenreLst = new List<string>();                                     
        //    var GenreQry = from d in db.Books
        //                   orderby d.Genre
        //                   select d.Genre;

        //    GenreLst.AddRange(GenreQry.Distinct());
        //    ViewBag.bookGenre = new SelectList(GenreLst);
        //    return GenreLst; 
        //}


        private IEnumerable<string> RetrieveGenreList()
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in db.Books
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.bookGenre = new SelectList(GenreLst);
            return GenreLst;
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
