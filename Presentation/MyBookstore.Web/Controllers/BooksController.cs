using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookstore.Services;
using System.Web;
using MyBookstore.Data;
using MyBookstore.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Models;
using PagedList;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using FluentValidation.Attributes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBookstore.Web
{
    [Route("Books")]
    public class BooksController : Controller
    {
        IHostingEnvironment _appEnvironment;
        private readonly IMyBookstoreService _myBookstoreService;
        private readonly IAuthorService _authorsServices;
        private readonly IBookService _booksServices;
        private readonly IPictureService _pictureService;

        public BooksController(IMyBookstoreService myBookstoreService, IHostingEnvironment appEnvironment,
            IAuthorService authorsServices, IBookService booksServices, IPictureService pictureService)
        {
            _appEnvironment = appEnvironment;
            _myBookstoreService = myBookstoreService;
            _authorsServices = authorsServices;
            _booksServices = booksServices;
            _pictureService = pictureService;
        }

        [HttpGet("showBook/{id}")]
        public async Task<IActionResult> ShowBook(int id)
        {


            return View(_booksServices.GetBookById(id));
        }


        public async Task<IActionResult> GetBooks()
        {
            return View(await _booksServices.GetBooksAsync());
        }

        [HttpPost("editBook/{bookId}")]
        public async Task<IActionResult> EditBookAsync([FromForm]BookViewModel model)
        {

            var entity = model.ToEntity();
            if (model.BookId == 0)
            {
                await _booksServices.CreatedBookAsync(entity);
                if (model.UploadedPicture != null)
                {
                    await _pictureService.AddPicture(entity.Id, model.UploadedPicture, true);
                }
            }
            else
            {
                entity.Id = model.BookId;
                if (model.UploadedPicture != null)
                {
                    if (model.ImageIsMain)
                        await _pictureService.DeleteMainPicture(entity.Id);

                    await _pictureService.AddPicture(entity.Id, model.UploadedPicture, model.ImageIsMain);

                }
                await _booksServices.UpdateBook(entity);
            }
            return Redirect("/");


        }

        public ActionResult Details(int id)
        {

            return View(_booksServices.Details(id));

        }

        [HttpGet("deleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _booksServices.DeleteBookAsync(id);
            return Redirect("/");

        }

        [HttpGet("editBook/{id}")]
        public async Task<IActionResult> EditBook(int id)
        {
            BookViewModel book = _booksServices.GetBookById(id); ;

            if (book == null)
            {
                book = new BookViewModel();
                book.Name = "New Book";
            }

            var authors = await _booksServices.AuthorDropdownAsync();
            book.Authors = authors;



            return View(book);
        }
    }
}
