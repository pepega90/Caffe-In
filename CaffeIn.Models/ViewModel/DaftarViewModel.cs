using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaffeIn.Models.ViewModel
{
    public class DaftarViewModel
    {
        [Required(ErrorMessage = "E-Mail tidak boleh kosong!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Konfirmasi Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Konfirmasi Password tidak sama dengan password!")]
        public string KonfirmasiPassword { get; set; }
    }
}
