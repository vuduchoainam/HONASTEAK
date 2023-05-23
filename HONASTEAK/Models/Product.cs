using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HONASTEAK.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
        public ICollection<OptionProduct> OptionProducts { get; set; }
        public ICollection<PropertyProduct> PropertyProducts { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public int Show { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}