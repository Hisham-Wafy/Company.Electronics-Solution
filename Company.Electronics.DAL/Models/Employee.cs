using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Company.Electronics.DAL.Models
{
    public class Employee : BaseEntity
    {
       
       
        [Range(18,60 , ErrorMessage="Must be Between from 18 to 60") ]
        public int? Age { get; set; }
       
        public string Address {  get; set; }
        [Required(ErrorMessage = "Salary Is Requires!!")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public int? WorkforId { get; set; }
        public Department? Workfor { get; set; }
    }
}
