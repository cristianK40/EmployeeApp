using EmployeeData.Models;

namespace EmployeeBusiness.Interfaces
{
    public interface IEmployeeService
    {
        void GetAnualSalary(List<Employee> employees);
        void GetAnualSalaryId(Employee employees);
    }
}
