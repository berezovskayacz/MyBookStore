using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Core;
using MyBookstore.Models;

namespace MyBookstore.Services
{
    public interface IBookService
    {
        IQueryable<Book> GetBooks(int? authorId, string bookName, int pageSize, int pageNumber);
        Task<HomePageViewModel> Filter(int? author, string name);
        Task CreatedBookAsync(Book b);
        Task<IEnumerable<SelectListItem>> AuthorDropdownAsync();
        Task<BookPageViewModel> GetBooksAsync();
        BookViewModel GetBookById(int id);
        Task<BookViewModel> Details(int? id);
        Task UpdateBook(Book b);
        Task<List<Book>> GetCarouselBooksAsync();
        Task DeleteBookAsync(int bookId);
    }
}
