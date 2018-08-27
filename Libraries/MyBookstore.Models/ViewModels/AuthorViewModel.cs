using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Models
{
    public class AuthorViewModel : MyBookstoreBaseModel

    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }

        public int BirthYear { get; set; }

        public int DeathYear { get; set; }

        public int Rate { get; set; }

            }
}
