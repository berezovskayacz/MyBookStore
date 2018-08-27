using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class Review : BaseEntity
    {
        public string UserName { get; set; }

        public string Text { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }


    }
}
