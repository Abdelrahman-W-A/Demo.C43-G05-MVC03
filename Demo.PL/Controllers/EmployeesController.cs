using Demo.BLL.Data_Transfer_Objects__DTOs_.EmployeeDTOs;
using Demo.BLL.Services.DepartmentServices;
using Demo.BLL.Services.EmployeeServices;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices, IWebHostEnvironment environment, ILogger<EmployeesController> logger) : Controller
    {
        #region Index
        [HttpGet]
        public IActionResult Index(string? EmployeeSearchName)
        {
            var Employees = _employeeServices.GetAllEmployees(EmployeeSearchName);
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
        public IActionResult Create(EmployeeViewModel employeeDTO)
        {
            if (ModelState.IsValid) // server side validation
            {
                try
                {
                    var employee = new AddNewEmployeeDTO()
                    {
                        Name = employeeDTO.Name,
                        Salary = employeeDTO.Salary,
                        Email = employeeDTO.Email,
                        PhoneNumber = employeeDTO.PhoneNumber,
                        IsActive = employeeDTO.IsActive,
                        HiringDate = employeeDTO.HiringDate,
                        EmployeeType = employeeDTO.EmployeeType,
                        Age = employeeDTO.Age,
                        gender = employeeDTO.gender,
                        DepartmentID = employeeDTO.DepartmentID
                    };
                    int result = _employeeServices.AddEmployee(employee);
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

            var employeeViewModel = new EmployeeViewModel()
            {
                Name = employee.Name,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                gender = employee.gender,
                EmployeeType = employee.EmployeeType,
                DepartmentID = employee.DepartmentID,
                Age = employee.Age,
            };
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel updatedmployeeDTO)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(updatedmployeeDTO);

            try
            {
                var employee = new UpdatedmployeeDTO()
                { 
                    Id = id.Value,
                    Name = updatedmployeeDTO.Name,
                    Salary = updatedmployeeDTO.Salary,
                    Email = updatedmployeeDTO.Email,
                    PhoneNumber = updatedmployeeDTO.PhoneNumber,
                    IsActive = updatedmployeeDTO.IsActive,
                    HiringDate = updatedmployeeDTO.HiringDate,
                    EmployeeType = updatedmployeeDTO.EmployeeType,
                    Age = updatedmployeeDTO.Age,
                    gender = updatedmployeeDTO.gender,
                    DepartmentID = updatedmployeeDTO.DepartmentID
                };

                var Result = _employeeServices.UpdateEmployee(employee);
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
    

