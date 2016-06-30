﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Interface.Presentation.Models.User
{
    public class UserEditAccountViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        public String Image { get; set; }

        [DisplayName("New Photo")]
        public HttpPostedFileBase File { get; set; }

        [DisplayName("Old Password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must have: minimun length of 8 characters, a number, a low case word and a hight case word.")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public String OldPassword { get; set; }


        [DisplayName("New Password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must have: minimun length of 8 characters, a number, a low case word and a hight case word.")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public String NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm  New Password")]
        [Compare("NewPassword", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

    }
}