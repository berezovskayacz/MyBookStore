using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Models
{
    public class BookPageViewModel : MyBookstoreBaseModel
    {
        public List<BookViewModel> Books { get; set; }

        public BookPageViewModel()
        {
            Books = new List<BookViewModel>();

        }





    }
}
