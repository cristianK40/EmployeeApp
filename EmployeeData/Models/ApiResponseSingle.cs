using System.Text.Json.Serialization;
namespace EmployeeData.Models
{
    public class ApiResponseSingle: ApiResponseBase<Employee>
    {
        [JsonPropertyName("data")]
        public Employee? SingleEmployee { get; set; }
        public override List<Employee> Data => SingleEmployee is not null ? new List<Employee> { SingleEmployee } : new();
    }
}
