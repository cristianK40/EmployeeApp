using EmployeeBusiness.Interfaces;
using EmployeeData.Models;

namespace EmployeeBusiness.Services
{
    public class EmployeeService : IEmployeeService
    {
        public void GetAnualSalary(List<Employee> employees) 
        {
            foreach (Employee employee in employees) 
            {
                employee.Employee_anual_Salary = employee.Employee_salary * 12;
            }
        }
        public void GetAnualSalaryId(Employee employee) 
        {
            employee.Employee_anual_Salary = employee.Employee_salary * 12;
        }
    }
}
