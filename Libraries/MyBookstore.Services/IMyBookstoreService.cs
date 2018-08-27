using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Core;
using MyBookstore.Models;

namespace MyBookstore.Services
{
    public interface IMyBookstoreService
    {
  
        Task<HomePageViewModel> GetHomePageAsync(string authorSortOrder, int? authorId, string bookName, int currentPage, ApplicationUser applicationUser);
        

    }
}