using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeIn.Models.ViewModel
{
    public class TotalSummaryViewModel
    {
        public decimal ShoppingCartTotal { get; set; }

        public string DisplayTotal => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", ShoppingCartTotal);
    }
}
