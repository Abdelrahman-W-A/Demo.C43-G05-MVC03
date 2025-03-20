using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.DbContex;

namespace Demo.DAL.Data.Repostitories
{
    public class DepartmentRepostiory(ApplicationDbContext dbContext) : IDepartmentRepostiory
    // Constructor Injection
    {
        private readonly ApplicationDbContext _dbContext = dbContext; // Private field

        public Department? GetById(int id) // Get Department by Id
        {
            return _dbContext.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll(bool WithTracking = false) // Get all Departments
        {
            if (WithTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }

        public int Add(Department department) // Add Department
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Update(Department department) // Update Department
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();

        }
        public int Remove(Department department) // Delete Department
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }


    }
}
