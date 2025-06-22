using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StickerShopCMS.Models
{
    [Table("sale_item")]
    public class SaleItem
    {
        [Key]
        [Column("sale_item_id")]
        public int SaleItemId { get; set; }

        [Required]
        [Column("sale_id")]
        public int SaleId { get; set; }

        [Required]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
