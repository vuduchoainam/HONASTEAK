using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HONASTEAK.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public string PropertyProduct { get; set; }
        public string OptionProduct { get; set; }
        public Invoice Invoice { get; set; }
    }
}