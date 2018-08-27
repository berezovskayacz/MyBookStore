using MyBookstore.Data;
using System;
using MyBookstore.Models;
using MyBookstore.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyBookstore.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserViewModel GetUserById(Guid id)
        {
            UserViewModel result = new UserViewModel();
            var  user = _dbContext.Users
                .Where(b => b.Id == id)
                .FirstOrDefault();
            result = user.MapTo<ApplicationUser, UserViewModel>();
            return result;
        }



    }
}
