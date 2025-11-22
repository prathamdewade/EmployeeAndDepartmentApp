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

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
           return  await repo.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await repo.GetCategoryByIdAsync(id);
        }
    }
}
