namespace StickerShopCMS.DTOs
{
    public class SaleDTO
    {
        public int SaleId { get; set; } 
        public DateTime SaleDate { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }

        public List<SaleItemDTO> SaleItems { get; set; } = new(); 

    }
}
