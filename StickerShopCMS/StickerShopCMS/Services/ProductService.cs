using StickerShopCMS.Data;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;

using System;

namespace StickerShopCMS.Services
{
    /// <summary>
    /// Logic for managing operations.
    /// -GetAll(): Gets all products from the database.
    /// - AddProduct(): Adds a product using ProductDTO input.
    /// 
    /// Works with database context to handle CRUD operations behind the API
    /// </summary>
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
    }
}
