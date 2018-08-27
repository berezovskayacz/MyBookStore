using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }
        public ICollection<GenreBook> BookGenres { get; set; }
        public ICollection<AuthorGenre> AuthorGenres { get; set; }

    }
}
