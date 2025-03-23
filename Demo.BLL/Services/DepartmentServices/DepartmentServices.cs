using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.Data_Transfer_Objects__DTO_;
using Demo.BLL.Data_Transfer_Objects__DTOs_;
using Demo.BLL.Factories.DepartmentsFactory;
using Demo.DAL.Data.Repostitories.NoUsedRepo.Departments;
using Demo.DAL.Models;
namespace Demo.BLL.Services.DepartmentServices
{
    public class DepartmentServices(IDepartmentRepostiory _departmentRepostiory) : IDepartmentServices
    {

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepostiory.GetAll();

            var departmentToReturn = departments.Select(d => new DepartmentDTO()
            {
                DeptID = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = DateOnly.FromDateTime((DateTime)d.CreatedOn)
            });

            return departmentToReturn;
        }

        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepostiory.GetById(id);

            if (department is null) return null;
            else
            {
                var departmentToReturn = new DepartmentDetailsDTO()
                {
                    Id = department.Id,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = DateOnly.FromDateTime((DateTime)department.CreatedOn),
                    ModifiedBy = department.ModifiedBy,
                    ModifiedOn = DateOnly.FromDateTime((DateTime)department.ModifiedOn),
                    IsDeleted = department.IsDeleted,
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description
                };
                return departmentToReturn;
            }

        }

        public int AddDepartment(CreatedDepartmentDTO createdDepartment)
        {
            var department = createdDepartment.ToEntity();
            return _departmentRepostiory.Add(department);
        }

        public int UpdateDepartment(UpdatedDepartmentDTO updatedDepartment)
        {
            return _departmentRepostiory.Update(updatedDepartment.ToEntity());
        }

        public bool DeleteDepartment(int id)
        {
            var dept = _departmentRepostiory.GetById(id);
            if (dept is null) return false;
            else
            {
                int result = _departmentRepostiory.Remove(dept);
                if (result > 0) return true;
                else return false;
            }
        }
    }
}
