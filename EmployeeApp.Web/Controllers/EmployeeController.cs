using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
