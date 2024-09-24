using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Electronics.DAL.Models
{
    public class Department : BaseEntity
    {
       
        [Required(ErrorMessage = "Insert Code my friend")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Insert Date my friend")]
        public DateTime DateOfCreation { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
