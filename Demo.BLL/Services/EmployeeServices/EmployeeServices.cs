using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.Data_Transfer_Objects__DTO_;
using Demo.BLL.Data_Transfer_Objects__DTOs_;
using Demo.BLL.Data_Transfer_Objects__DTOs_.EmployeeDTOs;
using Demo.DAL.Data.Repostitories.EntityTypes;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demo.BLL.Services.EmployeeServices
{
    public class EmployeeServices(IEntityTypeRepo<Employee> _entity) : IEmployeeServices
    {
        public int AddEmployee(GetEmployeeDTO createdEmployee)
        {
            var Emp = createdEmployee.ToEntity();
            return _entity.Add(Emp);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _entity.GetById(id);
            if (employee is null) return false;
            else
            {
                int result = _entity.Remove(employee);
                if (result > 0) return true;
                else return false;
            }
        }

        public IEnumerable<GetEmployeeDTO> GetAllEmployees()
        {
            var Emp = _entity.GetAll();

            var EmpToReturn = Emp.Select(E => new GetEmployeeDTO()
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.age,
                IsActive = E.IsActive,
                Salary = E.Salary,
                Email = E.Email,
                gender = E.Gender,
                EmployeeType = E.EmployeeType
            });

            return EmpToReturn;
        }

        public GetEmployeeByIdDTO? GetEmployeeById(int id)
        {
            var employee = _entity.GetById(id);

            if (employee is null) return null;
            else
            {
                var ReturnEmployee = new GetEmployeeByIdDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.age,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                    gender = employee.Gender,
                    EmployeeType = employee.EmployeeType
                };

                return ReturnEmployee;
            }
        }

        public int UpdateEmployee(UpdatedmployeeDTO updatedEmployee)
        {
            return _entity.Update(updatedEmployee.ToEntity());
        }
    }
}
