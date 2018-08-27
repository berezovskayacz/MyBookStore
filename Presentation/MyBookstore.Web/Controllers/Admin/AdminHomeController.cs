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
    public class AdminHomeController : BaseController
    {

        IHostingEnvironment _appEnvironment;
        private readonly IMyBookstoreService _myBookstoreService;
        private readonly IAuthorService _authorsServices;
        private readonly IBookService _booksServices;

        public AdminHomeController(IMyBookstoreService myBookstoreService, IHostingEnvironment appEnvironment, IAuthorService authorsServices, IBookService booksServices, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _appEnvironment = appEnvironment;
            _myBookstoreService = myBookstoreService;
            _authorsServices = authorsServices;
            _booksServices = booksServices;
        }

        [Route("/admin")]
        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel();
            model.Books = new System.Collections.Generic.List<BookViewModel>();

            return View("~/Views/Admin/Index.cshtml", model);
        }
    }
}