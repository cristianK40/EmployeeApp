using EmployeeBusiness.Interfaces;
using EmployeeData.Interfaces;
using EmployeeData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeConsumer _employeeConsumer;
        private readonly IEmployeeService _employeeService;
        public EmployeeApiController(IEmployeeConsumer employeeConsumer, IEmployeeService employeeService) 
        {
            _employeeConsumer = employeeConsumer;
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAllEmployess")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try 
            {
                List<Employee> employess = await _employeeConsumer.GetEmployeesAsync();
                _employeeService.GetAnualSalary(employess);
                return Ok(employess);
            }
            catch (HttpRequestException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id) 
        {
            try
            {
                Employee employee = await _employeeConsumer.GetEmployeeById(id);
                _employeeService.GetAnualSalaryId(employee);
                return Ok(employee);
            }
            catch (HttpRequestException ex) 
            {
                return Content(ex.Message);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
