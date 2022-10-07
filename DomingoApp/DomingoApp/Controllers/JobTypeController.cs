using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    public class JobTypeController : Controller
    {
        // GET: EmployeeDAL
        JobTypeDAL jobTypeDAL = new JobTypeDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<JobTypeModel> jTList = new List<JobTypeModel>();
            jTList = jobTypeDAL.GetAllJobTypes().ToList();
            return View(jTList);
        }

        //Get Update JobType View
        [Route("JobType/Update/{jobTypeID}")]
        public IActionResult Update(int? jobTypeID)
        {
            if (jobTypeID == null)
            {
                return NotFound();
            }

            JobTypeModel jT = jobTypeDAL.GetJobTypeByJobTypeID(jobTypeID);

            if (jT == null)
            {
                return NotFound();
            }

            return View(jT);
        }

        //Update JobType
        [Route("JobType/Update/{jobTypeID}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int? jobTypeID, [Bind] JobTypeModel jT)
        {
            if (jobTypeID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                jobTypeDAL.UpdateJobType(jT);
                return RedirectToAction("Index");
            }
            return View(jobTypeDAL);
        }
    }
}
