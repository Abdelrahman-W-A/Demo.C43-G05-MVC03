using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.Data_Transfer_Objects__DTO_;
using Demo.BLL.Data_Transfer_Objects__DTOs_;
using Demo.BLL.Data_Transfer_Objects__DTOs_.EmployeeDTOs;
using Demo.BLL.Factories.EmployeesFactory;
using Demo.DAL.Data.Repostitories.EntityTypes;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demo.BLL.Services.EmployeeServices
{
    public class EmployeeServices(IEntityTypeRepo<Employee> _entity , IMapper _mapper) : IEmployeeServices
    {

        public int AddEmployee(AddNewEmployeeDTO createdEmployee)
        {
            var employee = _mapper.Map<AddNewEmployeeDTO , Employee>(createdEmployee);
            return _entity.Add(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _entity.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _entity.Update(employee) > 0 ? true : false;
            }
        }

        public IEnumerable<GetEmployeeDTO> GetAllEmployees()
        {
            var Emp = _entity.GetAll();

            //var EmpToReturn = Emp.Select(E => new GetEmployeeDTO()
            //{
            //    Id = E.Id,
            //    Name = E.Name,
            //    Age = E.age,
            //    IsActive = E.IsActive,
            //    Salary = E.Salary,
            //    Email = E.Email,
            //    gender = E.Gender,
            //    EmployeeType = E.EmployeeType
            //});

            var EmpToReturn = _mapper.Map<IEnumerable<Employee> , IEnumerable<GetEmployeeDTO>>(Emp);

            return EmpToReturn;
        }

        public GetEmployeeByIdDTO? GetEmployeeById(int id)
        {
            var employee = _entity.GetById(id);

            if (employee is null) return null;
            else
            {
                //var ReturnEmployee = new GetEmployeeByIdDTO()
                //{
                //    Id = employee.Id,
                //    Name = employee.Name,
                //    Age = employee.age,
                //    Address = employee.Address,
                //    IsActive = employee.IsActive,
                //    Salary = employee.Salary,
                //    Email = employee.Email,
                //    PhoneNumber = employee.PhoneNumber,
                //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                //    gender = employee.Gender,
                //    EmployeeType = employee.EmployeeType,
                //    CreatedBy = 1,
                //    CreatedOn = DateTime.Now,
                //    LastModifiedBy = 1,
                //    LastModifiedOn = DateTime.Now

                //};

                var ReturnEmployee = _mapper.Map<Employee, GetEmployeeByIdDTO>(employee);

                return ReturnEmployee;
            }
        }

        public int UpdateEmployee(UpdatedmployeeDTO updatedEmployee)
        {
            return _entity.Update(_mapper.Map<UpdatedmployeeDTO , Employee>(updatedEmployee));
        }
    }
}
