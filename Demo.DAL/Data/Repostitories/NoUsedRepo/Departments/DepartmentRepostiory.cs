using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.DbContex;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Data.Repostitories.NoUsedRepo.Departments
{
    public class DepartmentRepostiory(ApplicationDbContext dbContext) : EntitytypeCrudImplementations<DepartmentRepostiory>
    {

    }
}
