using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBookstore.Services;
using MyBookstore.Core;
using MyBookstore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace MyBookstore.Web
{
    public class HomeController : BaseController
    {

        IHostingEnvironment _appEnvironment;
        private readonly IMyBookstoreService _myBookstoreService;
        private readonly IAuthorService _authorsServices;
        private readonly IBookService _booksServices;

        public HomeController(IMyBookstoreService myBookstoreService, IHostingEnvironment appEnvironment, IAuthorService authorsServices, IBookService booksServices, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _appEnvironment = appEnvironment;
            _myBookstoreService = myBookstoreService;
            _authorsServices = authorsServices;
            _booksServices = booksServices;
        }


        public async Task<IActionResult> Index(HomePageViewModel model)
        {
            ViewData["SurnameSort"] = model.SortOrder = String.IsNullOrEmpty(model.SortOrder) ? "Surname_Asc" : "";
            return View(await _myBookstoreService.GetHomePageAsync(model.SortOrder, model.AuthorIdSearchParameter, model.BookNameSearchParameter, model.PageNumber, await GetCurrentUserAsync()));
        }

        public async Task<IActionResult> GetBooks()
        {
            return View(await _booksServices.GetBooksAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            var authors = await _booksServices.AuthorDropdownAsync();
            ViewBag.Authors = authors;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditBook(int id)
        {

            var authors = await _booksServices.AuthorDropdownAsync();
            ViewBag.Authors = authors;


            return View();
        }


        [HttpPost]

        public async Task<IActionResult> EditBook(Book b)
        {
            if (ModelState.IsValid)

            {
                await _booksServices.UpdateBook(b);

                return RedirectToAction("Index");
            }
            return View(b);


        }





    }
}