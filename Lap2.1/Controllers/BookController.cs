using Lap2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lap2._1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
       
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual-Author Name Book 1");
            books.Add("HTML5 & CSS Responsive web Design cookbook-Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"Quản lý dự án Công nghệ thông tin","Nguyễn Văn A","/Content/Images/book1cover.jpg","Edit","Delete"));
            books.Add(new Book(2,"Sách công nghệ thông tin và truyền thông Việt Nam","Trần Thị B","/Content/Images/book2cover.jpg","Edit","Delete"));
            books.Add(new Book(3,"Công nghệ thông tin, Lãnh đạo quản lý","Trương Lâm Hữu Lộc","/Content/Images/book3cover.jpg","Edit","Delete"));
            
            return View(books);
        }
        public string Hello()
        {
            return "My_name:Trương Lâm Hữu Lộc";
        }
        public string HelloStudent(string HuuLocTruong)
        {
            return "My_name:Trương Lâm Hữu Lộc"+ HuuLocTruong;
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Quản lý dự án Công nghệ thông tin", "Nguyễn Văn A", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "Sách công nghệ thông tin và truyền thông Việt Nam", "Trần Thị B", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Công nghệ thông tin, Lãnh đạo quản lý", "Trương Lâm Hữu Lộc", "/Content/Images/book3cover.jpg"));
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
            books.Add(new Book(1, "Quản lý dự án Công nghệ thông tin", "Nguyễn Văn A", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "Sách công nghệ thông tin và truyền thông Việt Nam", "Trần Thị B", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Công nghệ thông tin, Lãnh đạo quản lý", "Trương Lâm Hữu Lộc", "/Content/Images/book3cover.jpg"));
           
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
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Quản lý dự án Công nghệ thông tin", "Nguyễn Văn A", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "Sách công nghệ thông tin và truyền thông Việt Nam","Trần Thị B", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Công nghệ thông tin, Lãnh đạo quản lý", "Trương Lâm Hữu Lộc", "/Content/Images/book3cover.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    //Thêm mới sách
                    books.Add(book);
                }    
            }
            catch(RetryLimitExceededException/*dex*/)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel",books);
        }
    }
}