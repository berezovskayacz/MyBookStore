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
    public class MyBookstoreService : IMyBookstoreService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAuthorService _authorsServices;
        private readonly IBookService _booksServices;

        public MyBookstoreService(ApplicationDbContext dbContext, IAuthorService authorsServices, IBookService booksServices)
        {
            _dbContext = dbContext;
            _authorsServices = authorsServices;
            _booksServices = booksServices;


        }


        public async Task<HomePageViewModel> GetHomePageAsync(string authorSortOrder, int? authorId, string bookName, int pageNumber, ApplicationUser applicationUser)
        {
            HomePageViewModel homePageModel = new HomePageViewModel();
            homePageModel.Authors = (await _authorsServices.GetAuthors(authorSortOrder))?.ToModel();

            int pageSize = 3;
            homePageModel.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            homePageModel.TotalPages = ((await _booksServices.GetBooks(authorId, bookName, pageSize, homePageModel.PageNumber).CountAsync()) + pageSize - 1) / pageSize;
            homePageModel.Books = (await _booksServices.GetBooks(authorId, bookName, pageSize, homePageModel.PageNumber).Skip((homePageModel.PageNumber - 1) * pageSize).Take(pageSize)?.ToListAsync())?.ToModel();
            homePageModel.CarouselBooks = (await _booksServices.GetCarouselBooksAsync())?.ToModel();
            homePageModel.User = applicationUser;

            return homePageModel;
        }

       

        public async Task<BookViewModel> Details(int? id)
        {

            var book = await _dbContext.Books
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var result = book.ToNewModel();
            return result;

        }

        public async Task EditAuthor(Author a)
        {
            _dbContext.Entry(a).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();


        }

 
    }



}
