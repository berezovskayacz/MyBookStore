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

namespace MyBookstore.Web.Controllers
{
    public class UserController : Controller
    {
        IHostingEnvironment _appEnvironment;
        private readonly IMyBookstoreService _myBookstoreService;
        private readonly IPictureService _pictureService;
        private readonly IUserService _userService;

        public UserController(IMyBookstoreService myBookstoreService, IHostingEnvironment appEnvironment,
             IPictureService pictureService, IUserService userService)
        {
            _appEnvironment = appEnvironment;
            _myBookstoreService = myBookstoreService;
            _userService = userService;

            _pictureService = pictureService;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("showUser/{id}")]
        //public async Task<IActionResult> ShowUser(Guid id)
        //{

        //    //ViewData.Model = await _myBookstoreService.ShowBook(id);
        //    return View(_userService.GetUserById(id));
        //}
    }
}