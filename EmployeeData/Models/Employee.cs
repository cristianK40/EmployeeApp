using System.Text.Json.Serialization;

namespace EmployeeData.Models
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string? Employee_name { get; set; }

        [JsonPropertyName("employee_salary")]
        public int? Employee_salary { get; set; }

        [JsonPropertyName("employee_age")]
        public int? Employee_age { get; set; }

        [JsonPropertyName("profile_image")]
        public string? Profile_image { get; set; }

        public int? Employee_anual_Salary { get; set; }
    }
}
