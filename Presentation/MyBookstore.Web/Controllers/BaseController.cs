using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookstore.Core;

namespace MyBookstore.Web
{
    public class BaseController: Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        protected Guid _userId
        {
            get
            {
                var user = GetCurrentUserAsync().Result;
                return user.Id;
            }
        }

        protected string _userName
        {
            get
            {
                var user = GetCurrentUserAsync().Result;
                return user.UserName;
            }
        }

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

    }
}
