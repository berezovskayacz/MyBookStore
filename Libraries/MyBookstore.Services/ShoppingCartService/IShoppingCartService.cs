using MyBookstore.Core;
using MyBookstore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Services
{
    public interface IShoppingCartService
    {
        #region methods
        Task<ShoppingCartModel> GetShoppingCartAsync(Guid userId);
        Task AddToCartAsync(int bookId, Guid userId);
        Task RemoveFromCartAsync(int shoppingCartItemId);
        Task RemoveAllFromCartAsync(Guid userId);
        decimal GetItemTotal(decimal price, int quantity);
        #endregion
    }
}
