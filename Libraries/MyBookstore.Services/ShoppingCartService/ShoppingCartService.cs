using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public class ShoppingCartService : IShoppingCartService
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems;

        private readonly ApplicationDbContext _dbContext;

        public ShoppingCartService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShoppingCartModel> GetShoppingCartAsync(Guid userId)
        {
            var shoppingCartItems = await (from b in _dbContext.ShoppingCartItems
                                           where b.UserId == userId
                                           select b)
                                     .Include(t => t.User)
                                     .Include(t => t.Book)
                                     .ThenInclude(t=>t.Author)
                                     .ToListAsync();

            return shoppingCartItems?.ToModel();

        }

        public async Task AddToCartAsync(int bookId, Guid userId)
        {
            _dbContext.ShoppingCartItems.Add(new ShoppingCartItem { BookId = bookId, UserId = userId });
            await _dbContext.SaveChangesAsync();

        }

        public async Task RemoveFromCartAsync(int shoppingCartItemId)
        {
            ShoppingCartItem item = await (from b in _dbContext.ShoppingCartItems
                                           where b.Id == shoppingCartItemId
                                           select b)
                                           .FirstOrDefaultAsync();

            if (item != null)
            {
                _dbContext.ShoppingCartItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }


        }

        public async Task RemoveAllFromCartAsync(Guid userId)
        {
            var items = await (from b in _dbContext.ShoppingCartItems
                               where b.UserId == userId
                               select b)
                               .ToListAsync();

           
            if (items != null)
            {
                foreach (ShoppingCartItem item in items)
                {
                    _dbContext.ShoppingCartItems.Remove(item);

                }
                await _dbContext.SaveChangesAsync();
            }


        }


        public  decimal GetItemTotal(decimal price, int quantity)
        {
            var itemTotal = price * quantity;
            return  itemTotal;
                            

        }
    }

}

