using Demo.DAL.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        [Display(Name = "Is Active")]
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
        public int? DepartmentID { get; set; }
        public IFormFile? Image { get; set; }
    }
}
