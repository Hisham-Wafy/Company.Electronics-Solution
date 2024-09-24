using Company.Electronics.BLL.Interfaces;
using Company.Electronics.DAL.Data.Contexts;
using Company.Electronics.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Electronics.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(AppDBContext context) : base(context) 
        {
            
        }

        public IEnumerable<Employee> GetByName(string name)
        {
           var _name = _context.Employees.Where(E => E.Name.ToLower().Contains(name.ToLower())).Include(E => E.Workfor).ToList();
            return _name;
        }
    }
}
