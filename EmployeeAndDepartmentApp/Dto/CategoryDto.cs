namespace EmployeeAndDepartmentApp.Dto
{
    public class CategoryDto
    {
        public string CName { get; set; }
    }

    public class ProductDto
    {
        public string PName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
