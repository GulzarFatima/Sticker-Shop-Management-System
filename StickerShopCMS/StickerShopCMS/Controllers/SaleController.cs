using Microsoft.AspNetCore.Mvc;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;
using StickerShopCMS.Services;
using Microsoft.EntityFrameworkCore;


namespace StickerShopCMS.Controllers
{
   [ApiController]
    [Route("api/[controller]")]

    /// <summary>
    /// Controller for handling Sale operations.
    /// GET / POST / DELETE 
    /// </summary>

    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        // ------------------------------------------------------------------
        /// GET ALL SALES
        /// <summary>
        /// Returns all sales.
        /// </summary>
        /// <returns>List of sales</returns>
        /// <example>
        /// curl -X GET http://localhost:5011/api/Sale
        /// </example>
        [HttpGet]
        public ActionResult<List<Sale>> GetAll()
        {
            return _saleService.GetAll();
        }

        // ------------------------------------------------------------------
        /// GET SALE BY ID
        /// <summary>
        /// Returns a sale by ID.
        /// </summary>
        /// <param name="id">Sale ID</param>
        /// <returns>Sale or not found</returns>
        /// <example>
        /// curl -X GET http://localhost:5011/api/Sale/1
        /// </example>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _saleService.GetById(id);
            if (result is string)
                return NotFound(new { message = result });

            return Ok(result);
        }

        // ------------------------------------------------------------------
        /// ADD SALE
        /// <summary>
        /// Creates a new sale.
        /// </summary>
        /// <param name="dto">SaleDTO</param>
        /// <returns>Success message</returns>
        /// <example>
        /// curl -X POST http://localhost:5011/api/Sale \
        /// -H "Content-Type: application/json" \
        /// -d '{"saleId":1,"saleDate":"2024-06-01","quantitySold":3,"totalAmount":29.97}'
        /// </example>
        [HttpPost]
        public IActionResult Add(SaleDTO dto)
        {
            var message = _saleService.Add(dto);
            return Ok(new { message });
        }

        // ------------------------------------------------------------------
        /// DELETE SALE
        /// <summary>
        /// Deletes a sale by its ID.
        /// </summary>
        /// <param name="id">Sale ID</param>
        /// <returns>Success or not found</returns>
        /// <example>
        /// curl -X DELETE http://localhost:5011/api/Sale/1
        /// </example>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var message = _saleService.Delete(id);

            if (message.Contains("not found"))
                return NotFound(new { message });

            return Ok(new { message });
        }
    }
}
