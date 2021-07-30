using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int Age { get; set; }
        public string EmailId {get;set;}
        public string JoiningDate { get; set; }
        public string Designation { get; set; }
        public int CTC { get; set; }

    }
}
