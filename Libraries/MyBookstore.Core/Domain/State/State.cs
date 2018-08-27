using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class State : BaseEntity
    {

        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
