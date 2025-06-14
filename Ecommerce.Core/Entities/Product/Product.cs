﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities.Product
{
   public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]  
        public virtual Category Category { get; set; }
    }
}
