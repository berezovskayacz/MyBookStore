using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Core;
using MyBookstore.Data;
using MyBookstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookstore.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IQueryable<Book> GetBooks(int? authorId, string bookName, int pageSize, int pageNumber)
        {

            IQueryable<Book> books = (from b in _dbContext.Books
                                      where b.AuthorId == (authorId ?? b.AuthorId) && (string.IsNullOrEmpty(bookName) || b.Name.Contains(bookName))
                                      select b
                                      );

            return books;
        }

        public async Task<List<Book>> GetCarouselBooksAsync()
        {

            var books = await (from b in _dbContext.Books
                                      select b
                                      )
                                      .Take(20)
                                      .Include(b => b.Pictures)
                                      .ToListAsync();

            return books;
        }


        public async Task<HomePageViewModel> Filter(int? author, string name)
        {

            IQueryable<Book> books = _dbContext.Books;
            if (author != null && author != 0)
            {
                books = books.Where(p => p.AuthorId == author);
            }
            if (!String.IsNullOrEmpty(name))
            {
                books = books.Where(p => p.Name.Contains(name));
            }

            List<Author> authors = await _dbContext.Authors.ToListAsync();
            authors.Insert(0, new Author { Surname = "All", Id = 0 });

            HomePageViewModel result = new HomePageViewModel
            {
                BooksForFilter = books.ToSortModel().ToList(),
                AuthorSurnamesForFilter = new SelectList(authors, "Id", "Surname"),
                BookNameSearchParameter = name
            };

            return result;
        }


        public async Task CreatedBookAsync(Book b)
        {
            _dbContext.Books.Add(b);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(Book b)
        {
            _dbContext.Books.Update(b);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteBookAsync(int bookId)
        {

            Book item = await (from b in _dbContext.Books
                                           where b.Id == bookId
                                           select b)
                                           .FirstOrDefaultAsync();
            if (item != null)
            {
                _dbContext.Books.Remove(item);
                await _dbContext.SaveChangesAsync();
            }

        }


        public async Task<IEnumerable<SelectListItem>> AuthorDropdownAsync()
        {
            
            var authors = await _dbContext.Authors
                .Select(t => new SelectListItem() { Text = t.Surname + ", " + t.Name, Value = t.Id.ToString() })
                .ToListAsync();
            return authors;
        }



        public async Task<BookPageViewModel> GetBooksAsync()
        {
            var result = new BookPageViewModel();
            var books = await _dbContext.Books.Include(t=>t.Pictures).ToListAsync();
            result.Books = books?.ToModel();
            return result;
        }

        public BookViewModel GetBookById(int id)
        {
            BookViewModel result = new BookViewModel();
            Book book = _dbContext.Books
                .Where(b => b.Id == id)
                .Include(t => t.Pictures)
                .Include(t => t.Author)
                .FirstOrDefault();
            result = book.MapTo<Book, BookViewModel>();
            return result;
        }

        public async Task<BookViewModel> Details(int? id)
        {

            var book = await _dbContext.Books
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var result = book.ToNewModel();
            return result;

        }
    }
}
