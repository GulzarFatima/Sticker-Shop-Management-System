using StickerShopCMS.Data;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;

namespace StickerShopCMS.Services
{
    /// <summary>
    /// Service layer responsible for managing Product operations. 
    /// - Get all products
    /// - Add new product
    /// - Update product
    /// - Delete product
    /// - Get product by ID
    /// </summary>

    // ------------------------------------------------------------------
    /// GET ALL PRODUCTS
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList(); 
        }
    
        // ------------------------------------------------------------------
        // ADD NEW PRODUCT
        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="dto">ProductDTO containing product details</param>
        /// <example>
        /// curl -X 'POST' \
        /// 'http://localhost:5011/api/Product' \
        /// -H 'accept: */*' \
        /// -H 'Content-Type: application/json' \
        /// -d '{
        ///   "productName": "Jumping Froggy",
        ///   "productDescription": "Frog jumping",
        ///   "price": 44.99
        /// }'
        /// </example>   

        public void AddProduct(ProductDTO dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                ProductDescription = dto.ProductDescription,
                Price = dto.Price
            };

            _context.Products.Add(product); 
            _context.SaveChanges();
        }

        // ------------------------------------------------------------------
        // UPDATE AN EXISTING PRODUCT BY ID
        /// </summary>
        /// <param name="id">Product ID to update</param>
        /// <param name="dto">Updated product details</param>
        /// <example>
        /// curl -X 'PUT' \
        /// 'http://localhost:5011/api/Product/3' \
        /// -H 'accept: */*' \
        /// -H 'Content-Type: application/json' \
        /// -d '{
        ///   "productName": "Updated Froggy",
        ///   "productDescription": "Frog with crown",
        ///   "price": 59.99
        /// }'
        /// </example>

        public bool UpdateProduct(int id, ProductDTO dto)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return false;  // not found

            product.ProductName = dto.ProductName;
            product.ProductDescription = dto.ProductDescription;
            product.Price = dto.Price;

            _context.SaveChanges();
            return true;  // success
}

        // ------------------------------------------------------------------
        // DELETE A PRODUCT BY ID
        /// </summary>
        /// <param name="id">Product ID to delete</param>
        /// <example>
        /// curl -X 'DELETE' \
        /// 'http://localhost:5011/api/Product/3' \
        /// -H 'accept: */*'
        /// </example>

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return false; // Product not found

            // If product exists, remove it from the database
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true; // Product deleted successfully
        }

        // ------------------------------------------------------------------
        // GET PRODUCT BY ID
        /// <summary>
        /// Retrieves a single product by its ID.
        /// </summary>
        /// <returns>Product object if found & "Product not found" otherwise</returns>
        /// <example>
        /// curl -X 'GET' \
        /// 'http://localhost:5011/api/Product/3' \
        /// -H 'accept: text/plain'
        /// </example>

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }


    }
}
