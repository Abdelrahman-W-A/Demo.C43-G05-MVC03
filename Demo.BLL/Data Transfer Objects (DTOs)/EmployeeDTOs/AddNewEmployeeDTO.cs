using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.Shared;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Data_Transfer_Objects__DTOs_.EmployeeDTOs
{
    public class AddNewEmployeeDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        [Display (Name = "Is Active")]
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly HiringDate { get; set; }
        public EmployeeGender gender { get; set; }
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        public IFormFile? Image { get; set; }
    }
}
