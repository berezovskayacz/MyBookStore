using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Models
{
    public class HomePageViewModel : MyBookstoreBaseModel
    {
        public List<AuthorViewModel> Authors { get; set; }
        public List<BookViewModel> Books { get; set; }
        public List<BookViewModel> CarouselBooks { get; set; }
        //public LoginViewModel User { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
        public string SortOrder { get; set; }
        public int? AuthorIdSearchParameter { get; set; }
        public string BookNameSearchParameter { get; set; }
        public SelectList AuthorSurnamesForFilter { get; set; }
        public IEnumerable<BookViewModel> BooksForFilter { get; set; }
    }
}
