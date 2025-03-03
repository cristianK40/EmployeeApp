using System.Text.Json.Serialization;

namespace EmployeeData.Models
{
    public class ApiResponseBase<T>
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        public virtual List<Employee> Data { get; set; }
    }
}
