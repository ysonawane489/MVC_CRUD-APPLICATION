

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.DAL;
using MVC_CRUD.Models;
using System.Linq;
using static MVC_CRUD.Filterss.CacheResourceFilter;
namespace MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository empRepo;
        public EmployeeController(EmployeeContext _dbcontext)
        {
            empRepo = new EmployeeRepository(_dbcontext);
        }
     //  [Authorize("Read")]
        public IActionResult Index()
        {
            var test = empRepo.GetEmployees().ToList();
            var lstEmployees = empRepo.GetEmployees().Select(e => new EmployeeViewModel
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Age = e.Age,
                EmailId = e.EmailId,
                JoiningDate=e.JoiningDate,
                Designation=e.Designation,
                CTC=e.CTC

            }).ToList();
            return View(lstEmployees);
            
        }

       
        [HttpGet]
      //  [Authorize("Read")]
        public IActionResult Create()
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            return View(emp);
        }

       
        [HttpPost]
       // [Authorize("Read")]
        public IActionResult Create(EmployeeViewModel emp)

        {
            if (ModelState.IsValid)
            {
                Employee empEntity = new Employee()
                {
                    EmpId = emp.EmpId,
                    EmpName = emp.EmpName,
                    Age = emp.Age,
                    EmailId = emp.EmailId,
                    JoiningDate = emp.JoiningDate,
                    Designation = emp.Designation,
                    CTC = emp.CTC
                };
                empRepo.CreateEmployee(empEntity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            EmployeeViewModel selecteEmployee = empRepo.GetEmployees().Where(i => i.EmpId == id).Select(e => new EmployeeViewModel
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Age = e.Age,
                EmailId = e.EmailId,
                JoiningDate = e.JoiningDate,
                Designation = e.Designation,
                CTC = e.CTC
            }).FirstOrDefault();
            return View(selecteEmployee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                Employee empEntity = new Employee()
                {
                    EmpId = emp.EmpId,
                    EmpName = emp.EmpName,
                    Age = emp.Age,
                    EmailId = emp.EmailId,
                    JoiningDate = emp.JoiningDate,
                    Designation = emp.Designation,
                    CTC = emp.CTC
                };
                empRepo.EditEmployee(empEntity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            EmployeeViewModel selecteEmployee = empRepo.GetEmployees().Where(i => i.EmpId == id).Select(e => new EmployeeViewModel
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Age = e.Age,
                EmailId = e.EmailId,
                JoiningDate = e.JoiningDate,
                Designation = e.Designation,
                CTC = e.CTC
            }).FirstOrDefault();
            return View(selecteEmployee);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            EmployeeViewModel selecteEmployee = empRepo.GetEmployees().Where(i => i.EmpId == id).Select(e => new EmployeeViewModel
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Age = e.Age,
                EmailId = e.EmailId,
                JoiningDate = e.JoiningDate,
                Designation = e.Designation,
                CTC = e.CTC
            }).FirstOrDefault();
            return View(selecteEmployee);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            empRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // [ValidateModel]
        [CacheResource]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        // [ValidateModel]
        [CacheResource]
        public IActionResult LogIn( int uid ,string username, string password)
        {
            LoginViewModel ValidUser = empRepo.GetUsers().Where(i =>i.Uid==uid && i.UserName == username && i.Password == password).Select(e => new LoginViewModel
            {
                
                UserName = e.UserName,
                Password = e.Password
            }).FirstOrDefault();
            if (ValidUser == null)
            {
                ViewBag.errormessage = "Enter Valid UserID,  Username and Password";
                return RedirectToAction("LogIn");
            }
            return RedirectToAction("Index");
        }


    }

}
    
