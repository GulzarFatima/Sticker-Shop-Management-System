using StickerShopCMS.Data;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;

namespace StickerShopCMS.Services
{
    /// <summary>
    /// Service class that handles business logic and data access for inventory.
    /// 
    /// - GetAll(): Gets all inventory records from the database.
    /// ----
    /// - AddInventory(): Adds a new inventory item.
    /// ----
    /// - GetById(): Retrieves inventory by ID.
    /// ----
    /// - UpdateInventory(): Updates an existing inventory item.
    /// ----
    /// - DeleteInventory(): Deletes an inventory item by ID.
    /// 
    /// This service is called by the InventoryController to process requests.
    /// </summary>
    public class InventoryService
    {
        // ------------------------------------------------------------------
        // DB CONTEXT INJECTION
        /// <summary>
        /// Injects the database context to access inventory data.
        /// </summary>
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------------
        // GET ALL INVENTORY
        /// <summary>
        /// Gets all inventory records from the database.
        /// </summary>
        /// <returns>List of Inventory objects.</returns>
        public List<Inventory> GetAll()
        {
            return _context.Inventory.ToList();
        }

        // ------------------------------------------------------------------
        // GET INVENTORY BY ID
        /// <summary>
        /// Retrieves a single inventory item by its ID.
        /// </summary>
        /// <param name="id">Inventory ID</param>
        /// <returns>Inventory object if found; null otherwise.</returns>
        public Inventory GetById(int id)
        {
            return _context.Inventory.FirstOrDefault(i => i.InventoryId == id);
        }

        // ------------------------------------------------------------------
        // ADD INVENTORY
        /// <summary>
        /// Adds a new inventory record to the database.
        /// </summary>
        /// <param name="dto">Inventory data transfer object</param>
        public void AddInventory(InventoryDTO dto)
        {
            var inventory = new Inventory
            {
                ProductId = dto.ProductId,
                QuantityAvailable = dto.QuantityAvailable,
                LastUpdated = DateTime.Now
            };

            _context.Inventory.Add(inventory);
            _context.SaveChanges();
        }

        // ------------------------------------------------------------------
        // UPDATE INVENTORY
        /// <summary>
        /// Updates an existing inventory item.
        /// </summary>
        /// <param name="id">Inventory ID</param>
        /// <param name="dto">Updated inventory values</param>
        /// <returns>Status string ("Updated." or "Not Found")</returns>
        public string UpdateInventory(int id, InventoryDTO dto)
        {
            var inventory = _context.Inventory.FirstOrDefault(i => i.InventoryId == id);
            if (inventory == null)
            {
                return "Not Found";
            }

            inventory.ProductId = dto.ProductId;
            inventory.QuantityAvailable = dto.QuantityAvailable;
            inventory.LastUpdated = DateTime.UtcNow;

            _context.Inventory.Update(inventory);
            _context.SaveChanges();
            return "Updated.";
        }

        // ------------------------------------------------------------------
        // DELETE INVENTORY
        /// <summary>
        /// Deletes an inventory record by ID.
        /// </summary>
        /// <param name="id">Inventory ID</param>
        /// <returns>Status string ("Deleted." or "Not Found")</returns>
        public string DeleteInventory(int id)
        {
            var inventory = _context.Inventory.FirstOrDefault(i => i.InventoryId == id);
            if (inventory == null)
            {
                return "Not Found";
            }

            _context.Inventory.Remove(inventory);
            _context.SaveChanges();
            return "Deleted.";
        }
    }
}
