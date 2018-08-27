using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class BookFormat : BaseEntity
    {
        public int FormatId { get; set; }
        public int BookId { get; set; }
        public Format Format { get; set; }
        public Book Book { get; set; }
    }
}
