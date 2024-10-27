﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Email is required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me ?")]
        public bool RememberMe { get; set; }

    }
}
