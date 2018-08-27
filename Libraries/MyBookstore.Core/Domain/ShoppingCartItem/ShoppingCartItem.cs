using Microsoft.AspNetCore.Http;
using MyBookstore.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Core
{
    public class ShoppingCartItem : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public Guid UserId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }
    }
}
