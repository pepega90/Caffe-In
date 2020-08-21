using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaffeIn.Models.ViewModel
{

    public class GantiPasswordViewModel
    {
        [Required(ErrorMessage = "Masukkan password!")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Masukkan password baru!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Konfirmasi password tidak boleh kosong!")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Kofirmasi password tidak sama!")]
        public string KonfirmasiPassword { get; set; }
    }
}
