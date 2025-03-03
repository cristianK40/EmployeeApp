using EmployeeData.Models;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeTests
{
    [TestClass]
    public class EmployeeTest
    {
        private Employee employee;
        [Setup]
        public void SetUp() 
        {
            Employee employee = new Employee();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
