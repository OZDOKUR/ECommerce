using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductImage
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }
}
