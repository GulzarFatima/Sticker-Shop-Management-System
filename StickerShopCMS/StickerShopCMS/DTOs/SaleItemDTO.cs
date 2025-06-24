 using Microsoft.AspNetCore.Mvc.ModelBinding;

 namespace StickerShopCMS.DTOs

{
    public class SaleItemDTO
    {
        [BindNever]
        public int SaleItemId { get; set; }

        public int SaleId { get; set; }   

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
