
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StickerShopCMS.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a product, 
    /// ...containing its name, description, and price.
    /// </summary>

    public class ProductDTO
    {
        [BindNever]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }

        [BindNever]
        public int CurrentQuantity { get; set; }
    }
}
