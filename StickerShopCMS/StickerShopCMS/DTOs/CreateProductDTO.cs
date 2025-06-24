namespace StickerShopCMS.DTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
