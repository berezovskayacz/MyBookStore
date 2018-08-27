using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBookstore.Core;
using MyBookstore.Models;
using MyBookstore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml.Linq;

namespace MyBookstore.Web.Controllers
{
    public class AddToCartController : Controller
    {

        IHostingEnvironment _appEnvironment;
        private readonly IUserService _userServices;
        private readonly IMailingService _mailingService;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public AddToCartController(IUserService userServices, IHostingEnvironment appEnvironment, IMailingService mailingService, UserManager<ApplicationUser> userManager)
        {
            _appEnvironment = appEnvironment;
            _userServices = userServices;
            _userManager = userManager;
            _mailingService = mailingService;

        }

               // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Add(BookViewModel book)
        {

            //if (Session["cart"] == null)
            //{
            //    List<BookViewModel> li = new List<BookViewModel>();

            //    li.Add(book);
            //    Session["cart"] = li;
            //    ViewBag.cart = li.Count();


            //    Session["count"] = 1;


            //}
            //else
            //{
            //    List<BookViewModel> li = (List<BookViewModel>)Session["cart"];
            //    li.Add(book);
            //    Session["cart"] = li;
            //    ViewBag.cart = li.Count();
            //    Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            //}
            return RedirectToAction("Index", "Home");


        }

    }
}
