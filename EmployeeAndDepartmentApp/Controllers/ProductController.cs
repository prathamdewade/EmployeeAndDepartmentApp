using EmployeeAndDepartmentApp.Dto;
using EmployeeAndDepartmentApp.Models;
using EmployeeAndDepartmentApp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAndDepartmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {

           IList<Product> products= await service.GetAllProductsAsync();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]  ProductDto dto)
        {
            Product product = new Product
            {
                PName = dto.PName,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
           bool res= await service.Add(product);
            return res
                ? Ok("Product Added Successfully")
                : BadRequest("Product with the same name already exists");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
