using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: InvoiceDAL
        InvoiceDAL invoiceDAL = new InvoiceDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<InvoiceModel> iList = new List<InvoiceModel>();
            iList = invoiceDAL.GetAllInvoices().ToList();
            return View(iList);
        }

        //Create Invoice
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] InvoiceModel invoice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    invoiceDAL.CreateInvoice(invoice);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }

                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
