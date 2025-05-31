using Microsoft.AspNetCore.Mvc;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;
using StickerShopCMS.Services;

namespace StickerShopCMS.Controllers
{

    [ApiController]

    [Route("api/[controller]")]


    /// <summary>
    /// GET: Returns list of all products.
    /// POST: Adds new product.
    /// Example GET Request:
    /// curl -X GET https://localhost:0000/api/Product
    /// Example POST request:
    /// curl -X POST https://localhost:0000/api/Product \
    /// -H "Content-Type: application/json" \
    /// -d '{"productName":"Frog Sticker","productDescription":"Crazy frog","price":1.80}'
    /// 
    /// Returns: A success message or error if input in invalid. 
    /// </summary>

    public class ProductController : ControllerBase
    {
        // connect controller to the ProductService
        private readonly ProductService _productService;

        // constructor to access the ProductService
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET request - get list of all products
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _productService.GetAll();
        }

        // POST request - create a new product
        [HttpPost]
        public IActionResult Create(ProductDTO dto)
        {
            // Validation - check if product name is empty - if yes, stop and show error.
            if (dto == null || string.IsNullOrWhiteSpace(dto.ProductName))
            {
                return BadRequest("Product name is required.");
            }

            // save the product using the ProductService
            _productService.AddProduct(dto);
            // return success message
            return Ok(new { message = "Product added!" });
        }
    }
}
