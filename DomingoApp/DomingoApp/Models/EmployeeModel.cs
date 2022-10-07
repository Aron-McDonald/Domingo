using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class EmployeeModel
    {
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Employee Number must be 6 characters")]
        public string employeeNo { get; set; }

        [Required]
        public string employeeName { get; set; }
    }
}
