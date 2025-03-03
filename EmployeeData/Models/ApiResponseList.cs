using EmployeeData.Models;
using System.Text.Json.Serialization;

public class ApiResponseList : ApiResponseBase<List<Employee>>
{
    [JsonPropertyName("data")]
    public override List<Employee> Data { get; set; } = new();
}