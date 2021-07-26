using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using System;


namespace MVC_CRUD.DAL
{
    public class EmployeeContext:DbContext
    {
        public  EmployeeContext(DbContextOptions<EmployeeContext>options):base(options)
        {
            ///con
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MVC_CRUD.Models.EmployeeViewModel> EmployeeViewModel { get; set; }

        public DbSet<Login> Userss { get; set; }
        public DbSet<MVC_CRUD.Models.LoginViewModel> LoginViewModel { get; set; }
    }
}
