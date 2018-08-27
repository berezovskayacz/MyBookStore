using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookstore.Models
{
    public class RegisterViewModel : MyBookstoreBaseModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

      
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Paswords")]
        public string PasswordConfirm { get; set; }

        public List<UIMessage> Messages { get; set; }
        public List<UIError> Errors { get; set; }

        public bool SuccessfullyCreated { get; set; }


        public RegisterViewModel()
        {
            Messages = new List<UIMessage>();
            Errors = new List<UIError>();
        }

    }
}
