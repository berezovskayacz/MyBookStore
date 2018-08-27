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

namespace MyBookstore.Web
{
    public class AuthorsController : Controller
    {

        IHostingEnvironment _appEnvironment;
        private readonly IAuthorService _athorsServices;
        public AuthorsController(IAuthorService athorsServices, IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _athorsServices = athorsServices;
        }



        public async Task<IActionResult> ShowAuthor(int id)
        {

            return View(_athorsServices.GetAuthorAsync(id));
        }


        public async Task<IActionResult> AllAuthors(string authorSortOrder)
        {
            return View(await _athorsServices.GetAllAuthorsPage(authorSortOrder));
        }


        [HttpGet]
        public async Task<IActionResult> EditAuthor(int id)
        {
            AuthorViewModel author;
            if (id == 0)
            {
                author = new AuthorViewModel();
            }
            else
            {
                author = await _athorsServices.GetAuthorAsync(id);
            }
            
            return View(author);
        }


        [HttpPost]
        public async Task<IActionResult> EditAuthor(AuthorViewModel a)
        {
            if (ModelState.IsValid)
            {
                var author = a.ToEntity();

                if(author.Id == 0)
                    await _athorsServices.CreateAuthorAsync(a.ToEntity());

                else
                    await _athorsServices.UpdateAuthorAsync(a.ToEntity());

                return RedirectToAction("AllAuthors");
            }
            return View(a);


        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _athorsServices.DeleteAthor(id);
            return RedirectToAction("AllAuthors");
        }

    }
}