using EmployeeAndDepartmentApp.Models;

namespace EmployeeAndDepartmentApp.Helper
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }

        public bool Status { get; set; }

        private ApiResponse(string Message, T Data, bool status)
        {
            this.Message = Message;
            this.Data = Data;
            this.Status = status;
        }

        public static ApiResponse<T> Success(String Message, T Data=default)
        {
            return new ApiResponse<T>(Message, Data, true);
        }

        public static ApiResponse<T> Failed(String Message, T Data = default)
        {
            return new ApiResponse<T>(Message, Data, false);
        }

    }
}


