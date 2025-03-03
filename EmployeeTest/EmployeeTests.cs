using EmployeeData.Models;
using EmployeeBusiness.Services;
namespace EmployeeTest
{
    [TestFixture]
    public class EmployeeTests
    {
        private Employee _employee;
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employee = new Employee();
            _employeeService = new EmployeeService();
        }

        [TestCase(3000, 36000)]
        [TestCase(4000, 48000)]
        [TestCase(5000, 60000)]
        public void GetAnualSalaryId_ShouldCalculateAnualSalary(int monthlySalary, int expectedAnnualSalary)
        {
            _employee.Employee_salary = monthlySalary;
            _employeeService.GetAnualSalaryId(_employee);
            Assert.That(_employee.Employee_anual_Salary == expectedAnnualSalary);
        }
        [Test]
        public void GetAnualSalary_ShouldCalculateAnualSalaryForAllEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Employee_salary = 3000 },
                new Employee { Employee_salary = 4000 },
                new Employee { Employee_salary = 5000 }
            };
            _employeeService.GetAnualSalary(employees);

            Assert.That(employees[0].Employee_anual_Salary, Is.EqualTo(36000));
            Assert.That(employees[1].Employee_anual_Salary, Is.EqualTo(48000));
            Assert.That(employees[2].Employee_anual_Salary, Is.EqualTo(60000));
        }
    }
}