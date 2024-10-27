using BookStoreWebApp.Models;
using BookStoreWebApp.Repository;
using BookStoreWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Controllers
{
    //[AllowAnonymous]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;


        public BookController(IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment, IUserService userService)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Route("all-books")]

        public async Task<IActionResult> GetAllBooks()
        {
            //var userId = _userService.GetUserId();
            //var isLogged = _userService.IsAunthenticated();
            var books = await _bookRepository.GetAllBooks();
            return View(books);
        }
        [Route("book-details/{id:int:min(1)}", Name = "bookDetailsRoute")]
        public async Task<IActionResult> GetBook(int id)
        {
            //var isLogged = _userService.IsAunthenticated();
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }
        public  List<BookModel> SearchBooks(string bookName, string authorName)
        {
           
            return _bookRepository.SearchBooks(bookName, authorName);
        }
        //[Authorize]
        public IActionResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bm)
        {
            if (ModelState.IsValid)
            {
                await UploadCoverPhoto(bm);
                await UploadGallery(bm);
                await UploadBookPDF(bm);
                int id = await _bookRepository.AddNewBook(bm);
                if (id > 0)
                {
                    //ViewBag.IsSuccess = isSuccess;
                    //ViewBag.BookId = bookId;
                    ModelState.Clear();
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.GetBookById(id);
            if (bookToDelete == null) return View("Not Found");
            return View(bookToDelete);
        }
        [HttpPost, ActionName("DeleteBook")]
        public async Task<IActionResult> DeleteBookConfirmed(int id)
        {
            var bookToDelete = await _bookRepository.GetBookById(id);
            if (bookToDelete == null) return View("Not Found");
            await _bookRepository.DeleteAsync(id);
            return RedirectToAction("GetAllBooks"); ;
        }

        // Adding a single CoverPhoto
        private async Task UploadCoverPhoto(BookModel bm)
        {
            if (bm.CoverPhoto != null)
            {
                string folder = "books/cover/";
                bm.CoverImageURL = await UploadImage(folder, bm.CoverPhoto);
            }
        }

        // Adding multiple Gallery Photos
        private async Task UploadGallery(BookModel bm)
        {
            if (bm.GalleryFiles != null)
            {
                string folder = "books/gallery/";
                //Creating a new instance of the Gallery List, will assign the values to it later in the loop.
                bm.GalleryList = new List<GalleryModel>();

                foreach (var file in bm.GalleryFiles)
                {
                    // Adding a new instance of the Gallery Model and setting the values in this instance.
                    var gallery = new GalleryModel()
                    {
                        Name = file.FileName,
                        URL = await UploadImage(folder, file)
                    };
                    // Adding the instance to the List of Gallery. It also set's the Id of the GalleryModel.
                    bm.GalleryList.Add(gallery);
                }
            }
        }
        // Adding a PDF to the book
        private async Task UploadBookPDF(BookModel bm)
        {
            if (bm.BookPDF != null)
            {
                string folder = "books/pdf/";
                bm.BookPdfURL = await UploadImage(folder, bm.BookPDF);
            }
        }

        // Generalized private method to Upload the images into the database, returns the Image URL appended with the GUID
        // This method will get a path and the file as parameters, we will append the path with the fileName and send it to database.
        private async Task<string> UploadImage(string folderPath, IFormFile img)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + img.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await img.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
