using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class Picture : BaseEntity
    {

        public string Name { get; set; } 
        public bool Main { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Path { get; set; }
    }
}
