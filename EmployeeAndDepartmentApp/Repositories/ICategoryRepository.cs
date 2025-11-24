using EmployeeAndDepartmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAndDepartmentApp.Repositories
{
    public interface ICategoryRepository 
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);

        public Task<bool> AddCategory(Category category);

        public Task<bool> UpdateCategory(Category category);
        public Task<bool> DeleteCategory(Category category);
    }


    public class  CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext db;
        public CategoryRepository(AppDbContext context)
        {
            db = context;
        }
        public async Task<bool> AddCategory(Category category)
        {
            await db.Categories.AddAsync(category);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCategory(Category category)
        {
             db.Categories.Remove(category);
            return await  db.SaveChangesAsync() > 0;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
          return  await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
           return await db.Categories.FirstOrDefaultAsync(c => c.CId == id);
        }

        public async Task<bool> UpdateCategory(Category category)
        {
             db.Categories.Update(category);
            return await db.SaveChangesAsync() > 0; 
        }
    }
}
