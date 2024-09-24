using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Electronics.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert Name my friend")]
        public string Name { get; set; }

    }
}
