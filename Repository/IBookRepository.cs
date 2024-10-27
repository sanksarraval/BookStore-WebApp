using BookStoreWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreWebApp.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBooks(string title, string authorName);
        Task DeleteAsync(int id);
    }
}