using EmployeeAndDepartmentApp.Models;
using EmployeeAndDepartmentApp.Repositories;

namespace EmployeeAndDepartmentApp.Service
{
    public interface IProductService
    {
        public Task<bool> Add(Product product );
        public Task<bool> Update(int id,Product product );
        public Task<bool> Delete(int id );
        public Task<IList<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;

        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }
        public async Task<bool> Add(Product product)
        {
           IList<Product> list= await repo.GetAllProductsAsync();
            foreach(var p in list)
            {
                if (p.PName.Equals(product.PName))
                    return false;
            }
            product.PName= product.PName.Trim();
            return await repo.AddProduct(product);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            return await repo.GetAllProductsAsync();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
