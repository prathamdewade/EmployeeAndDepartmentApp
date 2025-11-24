using EmployeeAndDepartmentApp.Dto;
using EmployeeAndDepartmentApp.Helper;
using EmployeeAndDepartmentApp.Models;
using EmployeeAndDepartmentApp.Service.Defination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAndDepartmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          List<Category> categories=  await service.GetAllCategoriesAsync();
           return categories.Count>0 
                 ? Ok( ApiResponse<IList<Category>>.Success("Data Retrive ", categories)   )
                : BadRequest( ApiResponse<string>.Failed("No Categories Found"));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Category cats =  await this.service.GetCategoryByIdAsync(id);
            return cats != null
                ? Ok(ApiResponse<Category>.Success("Data Retrive ", cats))
                : BadRequest(ApiResponse<string>.Failed("No Category Found"));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] CategoryDto dto)
        {
            Category category = new Category
            {
                CName= dto.CName
            };
            bool res=await this.service.AddCategoryAsync(category);
            return res
                ? Ok(ApiResponse<string>.Success("Category Added Successfully", category.CName))
                : BadRequest(ApiResponse<string>.Failed("Category with the same name already exists"));

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string CategoryName)
        {
            Category cats = new Category
            {
                CName= CategoryName
            };
            var res= await this.service.UpdateCategoryAsync(id, cats);
            return res
                ? Ok(ApiResponse<string>.Success("Category Updated Successfully", CategoryName))
                : BadRequest(ApiResponse<string>.Failed("No Category Found"));
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             var res=await this.service.DeleteCategoryAsync(id);
            return res
                ? Ok(ApiResponse<string>.Success("Category Deleted Successfully", id.ToString()))
                : BadRequest(ApiResponse<string>.Failed("No Category Found"));
        }
    }
}
