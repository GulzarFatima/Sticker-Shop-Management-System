using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StickerShopCMS.Models
{
        [Table("inventory")] 
        public class Inventory
    {
        [Key]
        [Column("inventory_id")] 
        public int InventoryId { get; set; }

        [Column("product_id")] 
        public int ProductId { get; set; }

        [Column("stock_level")]
        public int StockLevel { get; set; }

        [Column("last_updated")]
        public DateTime LastUpdated { get; set; }

        
    }
}
