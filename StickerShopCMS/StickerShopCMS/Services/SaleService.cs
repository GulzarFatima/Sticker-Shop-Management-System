using StickerShopCMS.Data;
using StickerShopCMS.DTOs;
using StickerShopCMS.Models;

namespace StickerShopCMS.Services
{
   /// <summary>
    /// Service for managing Sale operations. 
    /// - Get all sales
    /// - Add new sale
    /// - Get sale by ID
    /// - Delete sale
    /// </summary>

    public class SaleService
    {
        private readonly AppDbContext _context;

        public SaleService(AppDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------------
        // GET ALL SALES
        /// <summary>
        /// Returns all sales from the database.
        /// </summary>
        public List<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }

        // ------------------------------------------------------------------
        // GET SALE BY ID
        /// <summary>
        /// Get a sale by its ID.
        /// </summary>
        /// <param name="id">Sale ID</param>
        /// <returns>Sale or not found message</returns>
        public object GetById(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.SaleId == id);
            if (sale == null) return "Sale not found.";
            return sale;
        }

        // ------------------------------------------------------------------
        // ADD SALE
        /// <summary>
        /// Add a new sale to the database.
        /// </summary>
        /// <param name="dto">SaleDTO with sale details</param>
        /// <returns>Success message</returns>
        public string Add(SaleDTO dto)
        {
            var sale = new Sale
            {
                SaleDate = dto.SaleDate,
                QuantitySold = dto.QuantitySold,
                TotalAmount = dto.TotalAmount
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();

            return "Sale added successfully.";
        }

        // ------------------------------------------------------------------
        // DELETE SALE
        /// <summary>
        /// Delete a sale by ID.
        /// </summary>
        /// <param name="id">Sale ID</param>
        /// <returns>Success or not found message</returns>
        public string Delete(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.SaleId == id);
            if (sale == null)
                return "Sale with the given ID not found.";

            _context.Sales.Remove(sale);
            _context.SaveChanges();

            return "Sale deleted successfully.";
        }
    } 
}