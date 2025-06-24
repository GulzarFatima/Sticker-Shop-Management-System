namespace StickerShopCMS.DTOs
{
    public class UpdateProductDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
