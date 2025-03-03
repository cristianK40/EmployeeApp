using EmployeeData.Models;

namespace EmployeeApp.Business.Interfaces
{
    public interface IEmployeeService
    {
        void GetAnualSalary(List<Employee> employees);
    }
}
