using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StickerShopCMS.Models

{
    /// <summary>
    /// This class defines the Product entity used in the database.
    /// Includes ID, name, description and price of the product.
    /// It represents a single item sold in the sticker shop.
    /// </summary>
    /// 
    [Table("product")] 
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string? ProductName { get; set; }

  
        [Column("product_description")]
        public string? ProductDescription { get; set; }

       
        [Column("price")]
        public decimal Price { get; set; }

        [NotMapped]
        public int CurrentQuantity { get; set; }

    }
}
