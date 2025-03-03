using EmployeeData.Models;

namespace EmployeeApp.Business.Services
{
    public class EmployeeService
    {
        public void GetAnualSalary(List<Employee> employees) 
        {
            foreach (Employee employee in employees) 
            {
                employee.Employee_anual_Salary = employee.Employee_salary * 12;
            }
        }
    }
}
