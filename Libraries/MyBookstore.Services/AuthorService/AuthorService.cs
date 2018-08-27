using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Core;
using MyBookstore.Data;
using MyBookstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookstore.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HomePageViewModel> GetAllAuthorsPage(string authorSortOrder)
        {
            HomePageViewModel result = new HomePageViewModel();
            result.Authors = (await GetAuthors(authorSortOrder))?.ToModel();

            return result;
        }



        public async Task<List<Author>> GetAuthors(string authorSortOrder)
        {

            IQueryable<Author> authors = _dbContext.Authors;

            authorSortOrder = String.IsNullOrEmpty(authorSortOrder) ? "Surname_Desc" : "";

            switch (authorSortOrder)
            {
                case "Surname_Asc":
                    authors = authors.OrderBy(s => s.Surname);
                    break;
                case "Surname_Desc":
                    authors = authors.OrderByDescending(s => s.Surname);
                    break;
                case "Name_Asc":
                    authors = authors.OrderBy(s => s.Name);
                    break;
                case "Name_Desc":
                    authors = authors.OrderByDescending(s => s.Name);
                    break;
                default:
                    authors = authors.OrderBy(s => s.Surname);
                    break;
            }

            return await authors.ToListAsync();
        }


        public async Task DeleteAthor(int id)
        {
            Author a = await _dbContext.Authors.Where(b => b.Id == id).FirstOrDefaultAsync();
            _dbContext.Authors.Remove(a);
            await _dbContext.SaveChangesAsync();
        }


        public async Task CreateAuthorAsync(Author a)
        {
            _dbContext.Authors.Add(a);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<AuthorViewModel> GetAuthorAsync(int id)
        {
            AuthorViewModel result = new AuthorViewModel();
            Author author = await _dbContext.Authors
                .Where(b => b.Id == id)
                .Include(t => t.Books)
                .FirstOrDefaultAsync();
            result = author.MapTo<Author, AuthorViewModel>();
            return result;
        }

        public async Task UpdateAuthorAsync(Author a)
        {
            _dbContext.Authors.Update(a);
            await _dbContext.SaveChangesAsync();
        }

    }
}
