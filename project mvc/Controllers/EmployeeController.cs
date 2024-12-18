using project_mvc.Models;
using project_mvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _empservice;

        public ActionResult List()
        {
            _empservice = new EmployeeService();

            var model = _empservice.GetemployeeList();

            return View(model);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult AddEmployee(Employeemodel model)
        {
            _empservice = new EmployeeService();

            _empservice.InsertEmployee(model);


            return RedirectToAction("List");
        }

        public ActionResult EditEmployee(int Id)
        {
            _empservice = new EmployeeService();

            var model = _empservice.GetEditbyId(Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employeemodel model)
        {
            _empservice = new EmployeeService();

            _empservice.UpdateEmp(model);

            return RedirectToAction("List");
        }
        public ActionResult DeleteEmployee(int Id)
        {
            _empservice = new EmployeeService();

            _empservice.DeleteEmp(Id);

            return RedirectToAction("List");
        }
            
    }
}