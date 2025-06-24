using Microsoft.AspNetCore.Mvc;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;
using StickerShopCMS.Services;


namespace StickerShopCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    /// <summary>
    /// Controller for handling SaleItem operations.
    /// GET / POST / DELETE.
    /// </summary>

    public class SaleItemController : ControllerBase
    {
        private readonly SaleItemService _saleItemService;

        public SaleItemController(SaleItemService saleItemService)
        {
            _saleItemService = saleItemService;
        }

        // ------------------------------------------------------------------
        /// GET ALL SALE ITEMS
        /// <summary>
        /// Returns all sale items.
        /// </summary>
        /// <returns>List of SaleItem</returns>
        /// <example>
        /// curl -X GET https://localhost:0000/api/SaleItem
        /// </example>
        [HttpGet]
        public ActionResult<List<SaleItemDTO>> GetAll()
        {
            return _saleItemService.GetAll();
        }

        // ------------------------------------------------------------------
        /// GET SALE ITEM BY ID
        /// <summary>
        /// Returns a sale item by its ID.
        /// </summary>
        /// <param name="id">Sale item ID</param>
        /// <returns>Sale item or not found</returns>
        /// <example>
        /// curl -X GET https://localhost:0000/api/SaleItem/1
        /// </example>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _saleItemService.GetById(id);

            if (item is string message && message.Contains("not found"))
                return NotFound(new { message });

            return Ok(item);
        }

        // ------------------------------------------------------------------
        /// ADD SALE ITEM
        /// <summary>
        /// Adds a new sale item.
        /// </summary>
        /// <param name="dto">SaleItemDTO</param>
        /// <returns>Success message</returns>
        /// <example>
        /// curl -X POST https://localhost:0000/api/SaleItem \
        /// -H "Content-Type: application/json" \
        /// -d '{"saleId": 1, "productId": 2, "quantity": 5, "price": 12.99}'
        /// </example>

        [HttpPost]      
        public IActionResult Add([FromBody] CreateSaleItemDTO dto)

        {
        var result = _saleItemService.Add(dto);
        return Ok(new { message = "Sale item added successfully.", details = result });
        }   

        // ------------------------------------------------------------------
        /// DELETE SALE ITEM
        /// <summary>
        /// Deletes a sale item by its ID.
        /// </summary>
        /// <param name="id">Sale item ID</param>
        /// <returns>Success or not found message</returns>
        /// <example>
        /// curl -X DELETE https://localhost:0000/api/SaleItem/1
        /// </example>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _saleItemService.Delete(id);

            if (result == null)
             return NotFound("Sale item with the given ID was not found.");
            return Ok(new { message = result });
        }

    }
}