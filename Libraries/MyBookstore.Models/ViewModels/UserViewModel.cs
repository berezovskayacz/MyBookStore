using MyBookstore.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Models
{
    public class UserViewModel : MyBookstoreBaseModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //public ICollection<Review> Reviews { get; set; }
        ////public bool IsManager { get; set; }
        ////public Role Role { get; set; }
        ////public int RoleId { get; set; }
        //public ICollection<Order> UsersOrders { get; set; }
        //// public ICollection<Order> AssignedOrders { get; set; }
    }
}
