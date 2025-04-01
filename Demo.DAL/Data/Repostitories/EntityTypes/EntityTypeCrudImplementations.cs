using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.DbContex;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repostitories.EntityTypes
{
    public class EntityTypeCrudImplementations<T>(ApplicationDbContext _dbContext) : IEntityTypeRepo<T> where T : BaseEntity
    {
        public T? GetById(int id) // Get Department by Id
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(bool WithTracking = false) // Get all Departments
        {
            if (WithTracking)
                return _dbContext.Set<T>().Where(E=>E.IsDeleted != true).ToList();
            else
                return _dbContext.Set<T>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();
        }

        public int Add(T department) // Add Department
        {
            _dbContext.Set<T>().Add(department);
            return _dbContext.SaveChanges();
        }

        public int Update(T department) // Update Department
        {
            _dbContext.Set<T>().Update(department);
            return _dbContext.SaveChanges();

        }
        public int Remove(T department) // Delete Department
        {
            _dbContext.Set<T>().Remove(department);
            return _dbContext.SaveChanges();
        }

    }
}
