using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeIn.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int KopiId { get; set; }
        public virtual Kopi Kopi { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
