using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class JobCardModel
    {
        [Required]
        public int jobCardNo { get; set; }
        [Required]
        public int jobTypeID { get; set; }
        public string jobType { get; set; }
        [Required]
        public int NoOfDays { get; set; }
    }
}
