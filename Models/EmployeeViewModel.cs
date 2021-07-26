using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Models
{
    public class EmployeeViewModel
    {
        [Key]
        [Required (ErrorMessage ="Enter Employee Id")]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Enter Employee Name")]
        public string EmpName { get; set; }

        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }



    }
}
