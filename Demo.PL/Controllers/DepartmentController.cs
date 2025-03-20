using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices departmentServices) : Controller
    {

        public IActionResult Index()
        {

            var dept = departmentServices.GetDepartmentById(10);

            return View();
        }

    }
}
