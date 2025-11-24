using EmployeeAndDepartmentApp.Models;
using EmployeeAndDepartmentApp.Repositories;
using EmployeeAndDepartmentApp.Service.Defination;

namespace EmployeeAndDepartmentApp.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repo;

        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            IList<Category> cats = await repo.GetAllCategoriesAsync();
            if (cats.Count > 0)
            {
                foreach (var cat in cats)
                {
                    if (cat.CName.Equals(category.CName.ToLower()))
                    {
                        return false; // Category with the same name already exists
                    }
                }
            }
            category.CName=category.CName.Trim().ToLower();
            return  await repo.AddCategory(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
           Category cats= await repo.GetCategoryByIdAsync(id);
            if (cats == null)
                 return false;
            return await repo.DeleteCategory(cats);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
           return  await repo.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await repo.GetCategoryByIdAsync(id);
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            Category cats= await repo.GetCategoryByIdAsync(id);
            if (cats == null)
                return false;
            cats.CName= category.CName.Trim().ToLower();
            return await repo.UpdateCategory(cats);
        }
    }
}
