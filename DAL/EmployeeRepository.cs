using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.DAL
{
    public class EmployeeRepository
    {
        private EmployeeContext _dbcontext;
        public EmployeeRepository(EmployeeContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Employee>GetEmployees()
        {
            return _dbcontext.Employees.ToList();
        }

        public void CreateEmployee(Employee employee)
        {
            _dbcontext.Employees.Add(employee);
            _dbcontext.SaveChanges();
        }
        public void EditEmployee(Employee employee)
        {
            try {
                _dbcontext.Employees.Update(employee);
                _dbcontext.SaveChanges();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            finally
            {

            }
           }

        public void DeleteEmployee(int EmpId)
        {
              try  {
                var selectEmployee = _dbcontext.Employees.Where(i => i.EmpId == EmpId).FirstOrDefault();
                if(selectEmployee !=null)
                {
                    _dbcontext.Employees.Remove(selectEmployee);
                    _dbcontext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {

            }

        }
        public void ValidateUser(Login login)
        {
            try
            {
                var validate = (from user in _dbcontext.Userss
                                where user.UserName == login.UserName && user.Password == login.Password && user.Uid==login.Uid
                                select user).FirstOrDefault();
                if (validate == null)
                {
                    Console.WriteLine("Enter Valid Password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("LOGIN SUCCESSFULLY...!");
            }
        }
        public List<Login> GetUsers()
        {
            return _dbcontext.Userss.ToList();
        }
    }
}
