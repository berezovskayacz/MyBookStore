using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class Format : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BookFormat> BookFormats { get; set; }
    }
}
