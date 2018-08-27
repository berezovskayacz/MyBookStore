using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBookstore.Core;
using MyBookstore.Models;
using MyBookstore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookstore.Web.Controllers
{
    public class AccountController : BaseController
    {

        IHostingEnvironment _appEnvironment;
        private readonly IUserService _userService;
        private readonly IMailingService _mailingService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IUserService userService, SignInManager<ApplicationUser> signInManager, IHostingEnvironment appEnvironment, IMailingService mailingService, 
            UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _appEnvironment = appEnvironment;
            _userService = userService;
            _mailingService = mailingService;
            _signInManager = signInManager;
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;

            //await _mailingService.SendAsync(model.Email, "Registration Confirmed", "Thank you for joining us, " + model.Name + " !", true);
            //new MailController().RegisterEmail(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                model = new RegisterViewModel() { Name = "", Email = "", Surname = "", Password = "" };
                model.Messages.Add(new UIMessage() { Text = "User has been successfully created!" });
            }
            else
            {
                model.Errors.AddRange(result.Errors.Select(t=> new UIError() { Critical = true, Text = t.Description }).ToList());
            }

            model.SuccessfullyCreated = result.Succeeded;


            //if (ModelState.IsValid)
            //{
            //    User user = new User { Login = model.Email, Name = model.Email, Surname = model.Surname };
            //    // adding user
            //    var result = await _userManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        // set cookies
            //        await _signInManager.SignInAsync(user, false);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        foreach (var error in result.Errors)
            //        {
            //            ModelState.AddModelError(string.Empty, error.Description);
            //        }
            //    }
            //}

            return View(model);
        }



        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong email or password!");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet("showUser/{id}")]
        public async Task<IActionResult> ShowUser(Guid id)
        {

            return View(_userService.GetUserById(id));
        }
    }
}
