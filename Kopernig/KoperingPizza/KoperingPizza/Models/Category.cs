﻿using System.ComponentModel.DataAnnotations;

namespace KoperingPizza.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
