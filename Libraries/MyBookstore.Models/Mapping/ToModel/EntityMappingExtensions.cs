using MyBookstore.Core;
using System.Collections.Generic;
using System.Linq;

namespace MyBookstore.Models
{

    public static class EntityMappingExtensions
    {
        public static List<AuthorViewModel> ToModel(this List<Author> entity)
        {
            return entity.MapTo<List<Author>, List<AuthorViewModel>>();
        }

        public static List<BookViewModel> ToModel(this List<Book> entity)
        {
            return entity.MapTo<List<Book>, List<BookViewModel>>();
        }

        public static BookViewModel ToNewModel(this Book entity)
        {
            return entity.MapTo<Book, BookViewModel>();
        }

        public static ShoppingCartModel ToModel(this List<ShoppingCartItem> entity)
        {
            return entity.MapTo<List<ShoppingCartItem>, ShoppingCartModel>();
        }


        public static AuthorViewModel ToModel(this Author entity)
        {
            return entity.MapTo<Author, AuthorViewModel>();
        }

        public static List<BookViewModel> ToSortModel(this IQueryable<Book> entity)
        {
            return entity.MapTo<IQueryable<Book>, List<BookViewModel>>();
        }


        public static List<AuthorViewModel> ToSortModel(this IQueryable<Author> entity)
        {
            return entity.MapTo<IQueryable<Author>, List<AuthorViewModel>>();
        }

    }
}
