using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WishlistItem
    {
       
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
    }
}
