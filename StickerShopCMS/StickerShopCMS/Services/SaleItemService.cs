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

        public List<SaleItemDTO> GetAll()
        {
            return _context.SaleItems
                .Select(s => new SaleItemDTO
                {
                    SaleItemId = s.SaleItemId,
                    SaleId = s.SaleId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    Price = s.Price
                }).ToList();
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
        // ADD SALE ITEM
        /// <summary>
        /// Adds a new sale item and updates the inventory for the product.
        /// </summary>
        /// <param name="dto">CreateSaleItemDTO containing sale details</param>
        /// <returns>Success message or error</returns>
        /// <example>
        /// curl -X POST http://localhost:5011/api/SaleItem \
        /// -H "Content-Type: application/json" \
        /// -d '{"saleId":1,"productId":3,"quantity":2,"price":4.99}'
        /// </example>
        public string Add(CreateSaleItemDTO dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                // Check if the inventory record exists for the given product
                var inventory = _context.Inventories
                    .FirstOrDefault(i => i.ProductId == dto.ProductId);

                if (inventory == null)
                {
                    return $"Inventory not found for product ID {dto.ProductId}.";
                }

                // Update the inventory quantity (deduct sold quantity)
                inventory.StockLevel -= dto.Quantity;
                inventory.LastUpdated = DateTime.Now;

                // Add the sale item
                var saleItem = new SaleItem
                {
                    SaleId = dto.SaleId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    Price = dto.Price
                };
                _context.SaleItems.Add(saleItem);

                // Save changes and commit transaction
                _context.SaveChanges();
                transaction.Commit();

                return "Sale item added and inventory updated successfully.";
            }
                catch (Exception ex)
            {
                transaction.Rollback();
                return $"Error: {ex.InnerException?.InnerException?.Message ?? ex.ToString()}";
            }
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
