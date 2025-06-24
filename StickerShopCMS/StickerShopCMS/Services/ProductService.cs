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

    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

// ------------------------------------------------------------------
// GET ALL PRODUCTS
/// <summary>
/// Returns all products with their current quantity.
/// </summary>
public List<ProductDTO> GetAll()
{
    var products = _context.Products.ToList();

    var productDtos = products.Select(p =>
    {
        // Get latest stock level for the product
        var latestStock = _context.Inventories
            .Where(i => i.ProductId == p.ProductId)
            .OrderByDescending(i => i.LastUpdated)
            .Select(i => i.StockLevel)
            .FirstOrDefault();

        // Get total quantity sold for the product
        var totalSold = _context.SaleItems
            .Where(s => s.ProductId == p.ProductId)
            .Sum(s => (int?)s.Quantity) ?? 0;

        return new ProductDTO
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            ProductDescription = p.ProductDescription,
            Price = p.Price,
            CurrentQuantity = latestStock - totalSold
        };
    }).ToList();

    return productDtos;
}


        // ------------------------------------------------------------------
        // ADD NEW PRODUCT
        public void AddProduct(CreateProductDTO dto)
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
        public bool UpdateProduct(int id, UpdateProductDTO dto)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return false;

            product.ProductName = dto.ProductName;
            product.ProductDescription = dto.ProductDescription;
            product.Price = dto.Price;

            _context.SaveChanges();
            return true;
        }

        // ------------------------------------------------------------------
        // DELETE A PRODUCT BY ID
        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        // ------------------------------------------------------------------
        // GET PRODUCT BY ID
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
