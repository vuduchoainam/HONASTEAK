﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HONASTEAK.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
        public Table Table { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Payment { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public int Paid { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}