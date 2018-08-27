using MyBookstore.Core;
using MyBookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBookstore.Models
{
    public class ShoppingCartModel : MyBookstoreBaseModel
    {
        public IList<ShoppingCartItemModel> ShoppingCartItems { get; set; }

        public ShoppingCartModel()
        {
            ShoppingCartItems = new List<ShoppingCartItemModel>();
        }

        public decimal TotalAmount
        {
            get
            {
                return ShoppingCartItems.Sum(t => t.Qty * t.Book.Price);
            }
        }
        public decimal TotalQty
        {
            get
            {
                return ShoppingCartItems.Sum(t => t.Qty);
            }
        }



    }
}
