using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Enter your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your E-mail Id")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Enter a valid Email address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter a Strong Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm your password")]
        [Display(Name = "Confirm-Password")]
        [Compare("Password", ErrorMessage = "The Password doesn't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
