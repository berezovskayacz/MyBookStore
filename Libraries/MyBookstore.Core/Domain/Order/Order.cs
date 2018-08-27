using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Core
{
    public class Order : BaseEntity
    {

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public State OrderState { get; set; }
        public int StateId { get; set; }

        public DateTime CreatedOn { get; set; }

      
        public ICollection<Book> Books { get; set; }
        public ICollection<Format> OrderFormats { get; set; }

        public string OrderNote { get; set; }
        public bool PaperBook { get; set; }


    }
}
