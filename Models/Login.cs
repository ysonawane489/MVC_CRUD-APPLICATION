using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Models
{
    public class Login
    {
        [Key]
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
