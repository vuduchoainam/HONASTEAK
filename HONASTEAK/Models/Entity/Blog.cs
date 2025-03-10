﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HONASTEAK.Models.Entity
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Published { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
    }
}