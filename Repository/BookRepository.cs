using BookStoreWebApp.Data;
using BookStoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            // Created Instance of the Book Entity Class.
            //Mapping it to out context class.
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Language = model.Language,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageURL = model.CoverImageURL,
                BookPdfURL = model.BookPdfURL
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in model.GalleryList)
            {
                // Book Id will be populated automatically.
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        CoverImageURL = book.CoverImageURL,
                        BookPdfURL = book.BookPdfURL
                    });

                }
            }
            return books;
        }

        //Top-Books
        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {

            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                Language = book.Language,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageURL = book.CoverImageURL,
                BookPdfURL = book.BookPdfURL
            }).Take(count).ToListAsync();

        }



        public async Task<BookModel> GetBookById(int id)
        {
            // Used Linked Queries
            // Where() is applied on the datasource with a condition which checks the id.
            //FirstOrDefault() returns null if the contition is not satisfied

            return await _context.Books.Where(x => x.Id == id).Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                Language = book.Language,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageURL = book.CoverImageURL,
                GalleryList = book.bookGallery.Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList(),
                BookPdfURL = book.BookPdfURL
            }).FirstOrDefaultAsync();


            //var book = await _context.Books.FindAsync(id);
            //if (book != null)
            //{
            //    var bookDetails = new BookModel()
            //    {
            //        Author = book.Author,
            //        Category = book.Category,
            //        Description = book.Description,
            //        Id = book.Id,
            //        Language = book.Language,
            //        Title = book.Title,
            //        TotalPages = book.TotalPages,
            //        CoverImageURL = book.CoverImageURL,
            //        GalleryList = book.bookGallery.Select(g => new GalleryModel() { 
            //            Id = g.Id,
            //            Name = g.Name,
            //            URL = g.URL
            //        }).ToList()
            //    };
            //    return bookDetails;
            //}
            //return null;

            // Finding the book with some other parameter
            //_context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();

            //return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task DeleteAsync(int id)
        { 
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            var bookGallary = await _context.BookGallery.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Books.Remove(book);
            _context.BookGallery.Remove(bookGallary);
            await _context.SaveChangesAsync();
        }

        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id =1, Title = "MVC", Author="Sanskar", Description="This book teaches MVC and is written by Sanskar", Category = "Programming", Language = "English", TotalPages = 200 },
                new BookModel(){ Id =2, Title = ".NET Core", Author="Sanskar", Description="This book teaches .NET and is written by Sanskar", Category = "Framework", Language = "Hindi", TotalPages = 220},
                new BookModel(){ Id =3, Title = "C#", Author="Liza", Description="This book teaches C# and is written by Liza", Category = "Developer", Language = "Gujarati", TotalPages = 345},
                new BookModel(){ Id =4, Title = "Java", Author="Yash", Description="This book teaches Java and is written by Yash", Category = "Concept", Language = "Marathi", TotalPages = 287},
                new BookModel(){ Id =5, Title = "Php", Author="Avnit", Description="This book teaches Php and is written by Avnit", Category = "Programming", Language = "Kathiawadi", TotalPages = 321},
                new BookModel(){ Id =6, Title = "AWS", Author="Abhi", Description="This book teaches AWS and is written by Abhi", Category = "AWS", Language = "English", TotalPages = 123},
                new BookModel(){ Id =7, Title = "Azure Dev Ops", Author="Om", Description="This book is about Asure Dev Ops and is written by Om", Category = "DevOps", Language = "English", TotalPages = 456},

            };
        }
    }
}
