using EmployeeData.Models;
namespace EmployeeData.Interfaces
{
    public interface IEmployeeConsumer
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeById(int id);
    }
}
