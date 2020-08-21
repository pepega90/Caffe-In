using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CaffeIn.Models
{
    public class Kopi
    {
        public int Id { get; set; }
        public string NamaKopi { get; set; }
        public string Deskripsi { get; set; }
        public string PhotoPath { get; set; }
        public decimal Harga { get; set; }
        [NotMapped]
        public string DisplayHarga => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", Harga);
    }
}
