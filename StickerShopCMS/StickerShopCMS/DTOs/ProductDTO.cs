namespace StickerShopCMS.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a product, 
    /// ...containing its name, description, and price.
    /// </summary>
    
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
