using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Core
{
    public class Author : BaseEntity

    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }

        public string Description { get; set; }

        public int BirthYear { get; set; }

        public int DeathYear { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<AuthorGenre> AuthorGenres { get; set; }

        public int Rate { get; set; }
    }
}
