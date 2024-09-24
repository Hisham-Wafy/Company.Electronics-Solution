using Company.Electronics.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Electronics.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetByName(string name);


        //public IEnumerable<Employee> GetAll();
        //public Employee Get(int? id);
        //public int Add(Employee entity);
        //public int Update(Employee entity);
        //public int Delete(Employee entity);
    }
}
