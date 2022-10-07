using DomingoApp.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class InvoiceModel
    {
        public int invoiceNo { get; set; }
        [Required]
        public int jobCardNo { get; set; }
        [Required]
        public int customerID { get; set; }
        public string cutomerName { get; set; }
        public string address { get; set; }
        [Required]
        public int jobTypeID { get; set; }
        public string jobType { get; set; }
        public string employeeNo { get; set; }
        public string employeeName { get; set; }
        public string material { get; set; }
        public string quantity { get; set; }
        public double dailyRate { get; set; }
        public int NoOfDays { get; set; }
        public double subtotal { get; set; }
        public double VAT { get; set; }
        public double total { get; set; }
    }
}
