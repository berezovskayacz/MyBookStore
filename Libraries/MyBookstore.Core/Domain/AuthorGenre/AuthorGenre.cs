using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class AuthorGenre : BaseEntity
    {
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
