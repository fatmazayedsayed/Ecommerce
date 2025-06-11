﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities.Product
{
    public class Photo : BaseEntity<int>
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
