using DomingoApp.Models;
using DomingoApp.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    public class JobCardController : Controller
    {
        // GET: JobCardDAL
        JobCardDAL jobCardDAL = new JobCardDAL();
        public IActionResult Index()
        {
            //Get All JobCards
            List<JobCardModel> jCList = new List<JobCardModel>();
            jCList = jobCardDAL.GetAllJobCards().ToList();
            return View(jCList);
        }

        //Create JobCard
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] JobCardModel jC)
        {
            if (ModelState.IsValid)
            {
                jobCardDAL.CreateJobCard(jC);
                return RedirectToAction("Index");
            }
            return View(jC);
        }

        //Get JobCard Details
        [Route("JobCard/Details/{JobCardNo}")]
        [HttpGet]
        public IActionResult Details(int? jobCardNo)
        {
            if (jobCardNo == null)
            {
                return NotFound();
            }

            JobCardModel jC = jobCardDAL.GetJobCardByJobCardNo(jobCardNo);

            if (jC == null)
            {
                return NotFound();
            }

            return View(jC);
        }

        //Delete JobCard

        //Get Delete View
        [Route("JobCard/Delete/{JobCardNo}")]
        public IActionResult Delete(int? jobCardNo)
        {
            if (jobCardNo == null)
            {
                return NotFound();
            }
            JobCardModel jC = jobCardDAL.GetJobCardByJobCardNo(jobCardNo);

            if (jC == null)
            {
                return NotFound();
            }
            return View(jC);
        }

        //Perform Delete
        [Route("JobCard/Delete/{JobCardNo}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteJobCard(int? jobCardNo)
        {
            jobCardDAL.Delete(jobCardNo);
            return RedirectToAction("Index");
        }
    }
}
