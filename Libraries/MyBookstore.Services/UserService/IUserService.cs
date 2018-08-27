using MyBookstore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Services
{
    public interface IUserService
    {
        UserViewModel GetUserById(Guid id);
    }
}
