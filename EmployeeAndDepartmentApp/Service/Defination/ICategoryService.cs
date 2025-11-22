using EmployeeAndDepartmentApp.Models;

namespace EmployeeAndDepartmentApp.Service.Defination
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> AddCategoryAsync(Category category);
    }
}
