using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Core;
using MyBookstore.Models;

namespace MyBookstore.Services
{
    public interface IAuthorService
    {
        Task CreateAuthorAsync(Author a);
        Task DeleteAthor(int id);
        Task UpdateAuthorAsync(Author a);
        Task<HomePageViewModel> GetAllAuthorsPage(string authorSortOrder);
        Task<List<Author>> GetAuthors(string authorSortOrder);
        Task<AuthorViewModel> GetAuthorAsync(int id);
    }
}
