using Demo.BLL.Data_Transfer_Objects__DTOs_.EmployeeDTOs;
using Demo.BLL.Services.EmployeeServices;
using Demo.DAL.Models.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices, IWebHostEnvironment environment, ILogger<EmployeesController> logger) : Controller
    {
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _employeeServices.GetAllEmployees();
            return View(Employees);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddNewEmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid) // server side validation
            {
                try
                {
                    int result = _employeeServices.AddEmployee(employeeDTO);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        return View();
                    }
                }
                catch (Exception EX)
                {
                    if (environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, EX.Message);
                    }
                    else
                    {
                        logger.LogError(EX.Message);
                    }
                }
            }

            return View(employeeDTO);
        }

        #endregion

        #region Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            return employee == null ? NotFound() : View(employee);
        }

        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();

            var employeeDTO = new UpdatedmployeeDTO();
            {
                employeeDTO.Id = id.Value;
                employeeDTO.Name = employee.Name;
                employeeDTO.Address = employee.Address;
                employeeDTO.Salary = employee.Salary;
                employeeDTO.Email = employee.Email;
                employeeDTO.PhoneNumber = employee.PhoneNumber;
                employeeDTO.IsActive = employee.IsActive;
                employee.HiringDate = employee.HiringDate;
                employeeDTO.gender = employee.gender;
                employeeDTO.EmployeeType = employee.EmployeeType;
            }
            return View(employeeDTO);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdatedmployeeDTO updatedmployeeDTO)
        {
            if (!id.HasValue || id != updatedmployeeDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(updatedmployeeDTO);

            try
            {
                var Result = _employeeServices.UpdateEmployee(updatedmployeeDTO);
                if (Result > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not updated");
                    return View();
                }
            }
            catch (Exception EX)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, EX.Message);
                    return View(updatedmployeeDTO);
                }
                else
                {
                    logger.LogError(EX.Message);
                    return View("ErrorView", EX);
                }
            }

        }


        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var deleted = _employeeServices.DeleteEmployee(id.Value);
                if (deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not deleted");
                    return RedirectToAction(nameof(Delete), new { id = id });
                }
            }
            catch(Exception EX)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, EX.Message);
                    return RedirectToAction(nameof(Delete), new { id = id });
                }
                else
                {
                    logger.LogError(EX.Message);
                    return View("ErrorView", EX);
                }
            }
        }

        #endregion

    }
}
    

