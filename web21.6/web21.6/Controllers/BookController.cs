using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web21._6.Models;

namespace web21._6.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("Your Name - Author Name Book 1");
            books.Add("Your Lie In April - Author Name Book 2");
            books.Add("I want to eat your pancreas - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Your Name", "Author Name Book 1", "/Content/Images/book1cover.png"));
            books.Add(new Book(2, "Your Lie In April", " Author Name Book 2", "/Content/Images/book4cover.png"));
            books.Add(new Book(3, "I want to eat your pancreas ", " Author Name Book 3", "/Content/Images/book5cover.png"));
            return View(books);
        }

        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Your Name", "Author Name Book 1", "/Content/Images/book1cover.png"));
            books.Add(new Book(2, "Your Lie In April", " Author Name Book 2", "/Content/Images/book4cover.png"));
            books.Add(new Book(3, "I want to eat your pancreas ", " Author Name Book 3", "/Content/Images/book5cover.png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]

        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Your Name", "Author Name Book 1", "/Content/Images/book1cover.png"));
            books.Add(new Book(2, "Your Lie In April", " Author Name Book 2", "/Content/Images/book4cover.png"));
            books.Add(new Book(3, "I want to eat your pancreas", " Author Name Book 3", "/Content/Images/book5cover.png"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook ", " Author Name Book 2", "/Content/Images/book4cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVCS ", " Author Name Book 3", "/Content/Images/book5cover.png"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceedeException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

    }
}

