

using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.DAL;
using MVC_CRUD.Models;
using System.Linq;

namespace MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository empRepo;
        public EmployeeController(EmployeeContext _dbcontext)
        {
            empRepo = new EmployeeRepository(_dbcontext);
        }
        public IActionResult Index()
        {
            var test = empRepo.GetEmployees().ToList();
            var lstEmployees = empRepo.GetEmployees().Select(e => new EmployeeViewModel
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Age = e.Age,
                EmailId = e.EmailId

            }).ToList();
            return View(lstEmployees);
        }


        [HttpGet]
        public IActionResult Create()
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel emp)

        {
            if (ModelState.IsValid)
            {
                Employee empEntity = new Employee()
                {
                    EmpId = emp.EmpId,
                    EmpName = emp.EmpName,
                    Age = emp.Age,
                    EmailId = emp.EmailId
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
                EmailId = e.EmailId
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
                    EmailId = emp.EmailId
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
                EmailId = e.EmailId
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
                EmailId = e.EmailId
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
        public IActionResult Autherize()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autherize(string username, string password)
        {
            LoginViewModel validate = empRepo.GetUsers().Where(i => i.UserName == username && i.Password == password).Select(e => new LoginViewModel
            {
                UserName = e.UserName,
                Password = e.Password
            }).FirstOrDefault();
            if (validate == null)
            {
                ViewBag.errormessage = "Enter Invalid Username and Password";
                return RedirectToAction("Autherize");
            }
            return RedirectToAction("Index");
        }


    }

}
    
