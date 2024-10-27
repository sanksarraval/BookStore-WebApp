using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="Enter your current password"), DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Enter your New password"), DataType(DataType.Password)]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm your new password"), DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Does not match! Try Again")]
        public string ConfirmPassword { get; set; }

    }
}
