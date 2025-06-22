namespace StickerShopCMS.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a product, 
    /// ...containing its name, description, and price.
    /// </summary>
    
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CurrentQuantity { get; set; }
    }
}
