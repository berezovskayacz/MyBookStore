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
    public class ShoppingCartItemModel
    {
        public int Id { get; set; }
        public BookViewModel Book { get; set; }
        public int Qty { get; set; }
        public UserViewModel User { get; set; }
    }
}
