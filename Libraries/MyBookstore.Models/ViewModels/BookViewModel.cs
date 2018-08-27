using FluentValidation;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Models
{
    public class BookViewModel : MyBookstoreBaseModel
    {
        public BookViewModel()
        {
            Reviews = new List<Review>();
            BookGenres = new List<GenreBook>();
            BookFormats = new List<BookFormat>();
            Authors = new List<SelectListItem>();
            Pictures = new List<Picture>();
        }


        public string Name { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<GenreBook> BookGenres { get; set; }
        public bool PaperBook { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<BookFormat> BookFormats { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public string ThumbnailName { get; set; }
        public bool ImageIsMain { get; set; }
        public IFormFile UploadedPicture { get; set; }
    }

   
}
