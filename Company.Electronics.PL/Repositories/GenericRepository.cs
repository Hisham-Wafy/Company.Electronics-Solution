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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDBContext _context;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {

            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) _context.Employees.Include(E => E.Workfor).ToList();
            }

            return _context.Set<T>().ToList();
        }

        public T Get(int? id)
        {
            
            return _context.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();

        }

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();

        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();

        }



    }
}
