using StickerShopCMS.Data;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;

namespace StickerShopCMS.Services
{
    /// <summary>
    /// Service responsible for managing Sale Item operations.
    /// - Get all sale items
    /// - Get sale item by ID
    /// - Add new sale item
    /// - Delete sale item by ID
    /// </summary>

    public class SaleItemService
    {
        private readonly AppDbContext _context;

        public SaleItemService(AppDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------------
        // GET ALL SALE ITEMS
        /// <summary>
        /// Retrieves all sale items from the database.
        /// </summary>
        /// <returns>List of SaleItem objects</returns>
        /// <example>
        /// curl -X GET http://localhost:5011/api/SaleItem
        /// </example>

        public List<SaleItem> GetAll()
        {
            return _context.SaleItems.ToList();
        }

        // ------------------------------------------------------------------
        // GET SALE ITEM BY ID
        /// <summary>
        /// Retrieves a specific sale item by its ID.
        /// </summary>
        /// <param name="id">SaleItem ID</param>
        /// <returns>SaleItem object or "Sale item not found"</returns>
        /// <example>
        /// curl -X GET http://localhost:5011/api/SaleItem/1
        /// </example>

         public object GetById(int id)
        {
            var item = _context.SaleItems.FirstOrDefault(s => s.SaleItemId == id);

            if (item == null)

            return "Sale item with the given ID was not found.";

            return item;
        }

        // ------------------------------------------------------------------
        // ADD NEW SALE ITEM
        /// <summary>
        /// Adds a new sale item to the database.
        /// </summary>
        /// <param name="dto">SaleItemDTO containing sale item details</param>
        /// <example>
        /// curl -X POST http://localhost:5011/api/SaleItem \
        /// -H "Content-Type: application/json" \
        /// -d '{
        ///   "saleId": 1,
        ///   "productId": 2,
        ///   "quantity": 3,
        ///   "price": 19.99
        /// }'
        /// </example>

         public string Add(SaleItemDTO dto)
        {
            var saleItem = new SaleItem
            {
                SaleId = dto.SaleId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

            _context.SaleItems.Add(saleItem);
            _context.SaveChanges();

            return "Sale item added successfully.";
        }

        // ------------------------------------------------------------------
        // DELETE SALE ITEM BY ID
        /// <summary>
        /// Deletes a sale item by ID.
        /// </summary>
        /// <param name="id">SaleItem ID to delete</param>
        /// <returns>Success or "Sale item not found"</returns>
        /// <example>
        /// curl -X DELETE http://localhost:5011/api/SaleItem/1
        /// </example>

        public string Delete(int id)
        {
            var item = _context.SaleItems.FirstOrDefault(s => s.SaleItemId == id);
            if (item == null)
                return "Sale item not found.";

            _context.SaleItems.Remove(item);
            _context.SaveChanges();

            return "Sale item deleted successfully.";
        }
    }
}
