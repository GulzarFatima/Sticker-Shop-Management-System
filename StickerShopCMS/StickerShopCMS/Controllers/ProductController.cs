using Microsoft.AspNetCore.Mvc;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;
using StickerShopCMS.Services;
using Microsoft.EntityFrameworkCore;


namespace StickerShopCMS.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    // --------------------------------------------------------------------
    /// ADD / DELETE / GET ALL / GET / PUT
    /// <summary>
    /// Controller for handling product-related operations.
    /// Supports GET, POST, PUT, DELETE.
    /// </summary>

    public class ProductController : ControllerBase
    {
        // connect controller to the IProductService
        private readonly ProductService _productService;

        // constructor to access the IProductService
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // --------------------------------------------------------------------
        /// GET ALL PRODUCTS
        /// <summary>
        /// GET: Returns list of all products.
        /// </summary>
        /// <returns>List of products</returns>
        /// <example>
        /// curl -X GET https://localhost:0000/api/Product
        /// </example>
    
        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAll()
        {
            return _productService.GetAll();
        }

        // --------------------------------------------------------------------
        /// Create NEW PRODUCT 
        /// <summary>
        /// POST: Create a new product.
        /// </summary>
        /// <param name="dto">Product DTO</param>
        /// <returns>Success message</returns>
        /// <example>
        /// curl -X POST https://localhost:0000/api/Product \
        /// -H "Content-Type: application/json" \
        /// -d '{"productName":"Frog Sticker","productDescription":"Crazy frog","price":1.80}'
        /// </example>

        [HttpPost]
        public IActionResult Create(ProductDTO dto)
        {
            // Validation - check if product name is empty - if yes, stop & show error.
            if (dto == null || string.IsNullOrWhiteSpace(dto.ProductName))
            {
                return BadRequest("Product name is required.");
            }

            // save the product using the ProductService
            _productService.AddProduct(dto);
            // return success message
            return Ok(new { message = "Product added!" });
        }

        // --------------------------------------------------------------------
        /// UPDATE AN EXISTING PRODUCT BY ID
        /// <summary>
        /// PUT: Update a product.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="dto">Updated product DTO</param>
        /// <returns>Success or not found</returns>
        /// <example>
        /// curl -X PUT https://localhost:0000/api/Product/1 \
        /// -H "Content-Type: application/json" \
        /// -d '{"productName":"Updated Frog","productDescription":"New desc","price":9.99}'
        /// </example>

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDTO dto)
        {
            var updated = _productService.UpdateProduct(id, dto);
            if (!updated)
                return NotFound("Product not found");

            return Ok(new { message = "Product updated successfully." });
        }

        // --------------------------------------------------------------------
        /// DELETE A PRODUCT BY ID
        ///<summary>
        /// DELETE: Remove a product by ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Success or not found</returns>
        /// <example>
        /// curl -X DELETE https://localhost:0000/api/Product/3
        /// </example>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            if (!deleted)
                return NotFound("Product not found.");

            return Ok(new { message = "Product deleted successfully." });
        }

        // --------------------------------------------------------------------
        /// GET PRODUCT BY ID
        /// <summary>
        /// GET: Get a product by ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product or 404</returns>
        /// <example>
        /// curl -X GET https://localhost:0000/api/Product/1
        /// </example>

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

    }
}
