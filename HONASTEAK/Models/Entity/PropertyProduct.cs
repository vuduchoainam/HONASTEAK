﻿using HONASTEAK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HONASTEAK.Models
{
    public class PropertyProduct
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
