using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HONASTEAK.Models.Entity
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<OptionProduct> Options { get; set; }
        public PropertyProduct PropertyProduct { get; set; }
    }
}