using Microsoft.AspNetCore.Mvc;
using StickerShopCMS.Models;
using StickerShopCMS.DTOs;
using StickerShopCMS.Services;
using Microsoft.EntityFrameworkCore;


namespace StickerShopCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        // ------------------------------------------------------------------
        // CONSTRUCTOR
        /// <summary>
        /// Injects the inventory service for handling logic.
        /// </summary>
        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // ------------------------------------------------------------------
        // GET ALL INVENTORY
        /// <summary>
        /// Get all inventory items from the database.
        /// </summary>
        [HttpGet]

        public ActionResult<List<Inventory>> GetAllInventory()
        {
            return _inventoryService.GetAll();
        }

        // ------------------------------------------------------------------
        // GET INVENTORY BY ID
        /// <summary>
        /// Returns a single inventory record by ID.
        /// </summary>
        /// <param name="id">Inventory ID</param>
        /// <returns>Inventory item if found, or 404</returns>
        [HttpGet("{id}")]
        public ActionResult<Inventory> GetInventoryById(int id)
        {
            var item = _inventoryService.GetById(id);
            if (item == null)
                return NotFound($"No inventory found with ID {id}.");
            return Ok(item);
        }

        // ------------------------------------------------------------------
        // CREATE INVENTORY RECORD
        /// <summary>
        /// Adds a new inventory item.
        /// </summary>
        /// <param name="dto">Inventory DTO</param>
        [HttpPost]
        public IActionResult AddInventoryItem(InventoryDTO dto)
        {
            _inventoryService.AddInventory(dto);
            return Ok(new { message = "Inventory item added." });
        }

        // ------------------------------------------------------------------
        // UPDATE INVENTORY RECORD
        /// <summary>
        /// Updates an inventory record by ID.
        /// </summary>
        /// <param name="id">Inventory ID</param>
        /// <param name="dto">Updated values</param>
        [HttpPut("{id}")]
        public IActionResult UpdateInventoryItem(int id, InventoryDTO dto)
        {
            var result = _inventoryService.UpdateInventory(id, dto);
            if (result == "Not Found") return NotFound("Inventory item not found.");
            return Ok(new { message = result });
        }

        // ------------------------------------------------------------------
        // DELETE INVENTORY RECORD
        /// <summary>
        /// Deletes an inventory record by ID.
        /// </summary>
        /// <param name="id">Inventory ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryItem(int id)
        {
            var result = _inventoryService.DeleteInventory(id);
            if (result == "Not Found") return NotFound("Inventory item not found.");
            return Ok(new { message = result });
        }
    }
}
