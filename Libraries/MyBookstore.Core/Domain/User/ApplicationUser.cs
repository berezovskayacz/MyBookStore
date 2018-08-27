using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public bool IsManager { get; set; }
        public ICollection<Order> UsersOrders { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
