using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaffeIn.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Mail tidak boleh kosong!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
