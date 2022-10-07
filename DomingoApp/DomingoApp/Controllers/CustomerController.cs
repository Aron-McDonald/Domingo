using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    public class CustomerController : Controller
    { 
        // GET: CustomerDAL
        CustomerDAL customerDAL = new CustomerDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<CustomerModel> cList = new List<CustomerModel>();
            cList = customerDAL.GetAllCustomers().ToList();
            return View(cList);
        }

        //Create Customer
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                customerDAL.CreateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //Edit Customer
        [Route("Customer/Edit/{customerID}")]
        public IActionResult Edit(int? customerID)
        {
            if (customerID == null)
            {
                return NotFound();
            }

            CustomerModel cust = customerDAL.GetCustomerByCustomerID(customerID);

            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        //Update Customer
        [Route("Customer/Edit/{customerID}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? customerID, [Bind] CustomerModel cust)
        {
            if (customerID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                customerDAL.UpdateCustomer(cust);
                return RedirectToAction("Index");
            }
            return View(customerDAL);
        }

        //Get Delete View
        [Route("Customer/Delete/{customerID}")]
        public IActionResult Delete(int? customerID)
        {
            if (customerID == null)
            {
                return NotFound();
            }
            CustomerModel cust = customerDAL.GetCustomerByCustomerID(customerID);

            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        //Perform Delete
        [Route("Customer/Delete/{customerID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteCustomer(int? customerID)
        {
            customerDAL.Delete(customerID);
            return RedirectToAction("Index");
        }
    }
}
