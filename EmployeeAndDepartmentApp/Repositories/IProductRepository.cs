using EmployeeAndDepartmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAndDepartmentApp.Repositories
{
    public interface IProductRepository
    {
        public Task<IList<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<IList<Product>> GetProductByCategoryIdAsync(int categoryId);
        public Task<bool> AddProduct(Product product);
        public Task<bool> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddProduct(Product product)
        {
             db.Products.AddAsync(product);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
                db.Products.Remove(product);
                return await db.SaveChangesAsync() > 0;
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
           return await  db.Products.Include(p=> p.Category).ToListAsync();
        }

        public async Task<IList<Product>> GetProductByCategoryIdAsync(int categoryId)
        {
            return await db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
             return await db.Products.FirstOrDefaultAsync(p => p.PId == id);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
             db.Products.Update(product);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
