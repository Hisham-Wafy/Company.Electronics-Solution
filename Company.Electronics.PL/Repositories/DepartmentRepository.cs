using Company.Electronics.BLL.Interfaces;
using Company.Electronics.DAL.Data.Configurations;
using Company.Electronics.DAL.Data.Contexts;
using Company.Electronics.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Electronics.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext _dbContext;

        public DepartmentRepository(AppDBContext dbContext)
        {
            
            _dbContext = dbContext;
        }
        public Department? Get(int? id)
        {
            //return _dbContext.Department.FirstOrDefault(D => D.Id == id);
            return _dbContext.Department.Find(id);

        }
        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Department.ToList();
        }
        public int Add(Department entity)
        {
            _dbContext.Department.Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(Department entity)
        {
            _dbContext.Department.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Department.Remove(entity);
            return _dbContext.SaveChanges();
        }



    }
}
