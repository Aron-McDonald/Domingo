using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomingoApp.Models;

namespace DomingoApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeDAL
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public IActionResult Index()
        {
            //Get All Employees
            List<EmployeeModel> empList = new List<EmployeeModel>();
            empList = employeeDAL.GetAllEmployees().ToList();
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel objEmp)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.AddEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(objEmp);
        }


        //Get Employee Details
        [Route("Employee/Details/{employeeNo}")]
        [HttpGet]
        public IActionResult Details(string employeeNo)
        {
            if (employeeNo == null)
            {
                return NotFound();
            }

            EmployeeModel emp = employeeDAL.GetEmployeeByEmployeeNo(employeeNo);

            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        //Edit Employees
        [Route("Employee/Edit/{employeeNo}")]
        public IActionResult Edit(string employeeNo)
        {
            if (employeeNo == null)
            {
                return NotFound();
            }

            EmployeeModel emp = employeeDAL.GetEmployeeByEmployeeNo(employeeNo);

            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        //Update Employee
        [Route("Employee/Edit/{employeeNo}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string employeeNo, [Bind] EmployeeModel objEmp)
        {
            if (employeeNo == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                employeeDAL.UpdateEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(employeeDAL);
        }

        //Get Delete View
        [Route("Employee/Delete/{employeeNo}")]
        public IActionResult Delete(string employeeNo)
        {
            if (employeeNo == null)
            {
                return NotFound();
            }
            EmployeeModel emp = employeeDAL.GetEmployeeByEmployeeNo(employeeNo);

            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        //Perform Delete
        [Route("Employee/Delete/{employeeNo}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteEmployee(string employeeNo)
        {
            employeeDAL.Delete(employeeNo);
            return RedirectToAction("Index");
        }
    }
}
