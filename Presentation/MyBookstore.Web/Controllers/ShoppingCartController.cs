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
    public class ShoppingCartController : BaseController
    {

        IHostingEnvironment _appEnvironment;
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Route("/ShoppingCart")]
        public async Task<IActionResult> Index()
        {
            var model = await _shoppingCartService.GetShoppingCartAsync(_userId);


            return View("~/Views/ShoppingCart/Index.cshtml", model);
        }

        [Route("/ShoppingCart/AddToCart/{bookId}")]
        public async Task<IActionResult> AddToCart(int bookId)
        {
            await _shoppingCartService.AddToCartAsync(bookId, _userId);
            return Redirect("/ShoppingCart");
        }

        [HttpGet("/ShoppingCart/RemoveFromCart/{itemId}")]
        public async Task<IActionResult> RemoveFromCart(int itemId)
        {
            await _shoppingCartService.RemoveFromCartAsync(itemId);
            return Redirect("/ShoppingCart");
        }


        [HttpGet("/ShoppingCart/RemoveFromCart")]
        public async Task<IActionResult> RemoveAllFromCart(Guid userId)
        {
            await _shoppingCartService.RemoveAllFromCartAsync(userId);
            return Redirect("/ShoppingCart");
        }


    }
}