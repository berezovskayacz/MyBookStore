using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<GenreBook> BookGenres { get; set; }
        public bool PaperBook { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<BookFormat> BookFormats { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
