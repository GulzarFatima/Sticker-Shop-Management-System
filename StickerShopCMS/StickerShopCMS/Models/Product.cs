using System.ComponentModel.DataAnnotations;

namespace StickerShopCMS.Models

{
    /// <summary>
    /// This class defines the Product entity used in the database.
    /// Includes ID, name, description and price of the product.
    /// It represents a single item sold in the sticker shop.
    /// </summary>
    /// 
    public class Product
    {
        public int ProductId { get; set; }

  
        public string? ProductName { get; set; }

  
        public string? ProductDescription { get; set; }

       
        public decimal Price { get; set; }
    }
}
