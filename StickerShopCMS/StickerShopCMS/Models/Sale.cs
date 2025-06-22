using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace StickerShopCMS.Models

{
    [Table("sale")]
    public class Sale
    {

        [Key]
        [Column("sale_id")]
        public int SaleId { get; set; }

        [Required]
        [Column("quantity_sold")]
        public int QuantitySold { get; set; }

        [Required]
        [Column("sale_date")]
        public DateTime SaleDate { get; set; } 

        [Required]
        [Column("total_amount", TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        // 1 Sale can have many SaleItems
        public List<SaleItem> SaleItems { get; set; } = new();

    }
}
