using JobBoard.Models.Job;
using JobBoard.Service.Job;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;

        public JobController(ILogger<JobController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        public async Task<IActionResult> JobIndex()
        {
            if (User.IsInRole("Company"))
            {
                var jobs = _jobService.GetJobListAsync().Result;
                return View(jobs);
            }
            else
            {
                var jobs = _jobService.GetAllJobsAsync().Result;
                return View(jobs);
            }
            
        }

        [Route("CreateJob")]
        public IActionResult CreateJob()
        {
            return View();
        }

        [Route("CreateJob")]
        [HttpPost]
        public async Task<IActionResult> CreateJob(JobCreate request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            await _jobService.CreateJobAsync(request);
            return RedirectToAction(nameof(JobIndex));
        }

        [Route("JobInfo/{id:int}")]
        public async Task<IActionResult> JobInfo(int id)
        {
            JobDetail job = await _jobService.GetJobByIdAsync(id);
            if (job is null)
            {
                return RedirectToAction(nameof(JobIndex));
            }
            return View(job);
        }

        [Route("AllJobs")]
        [HttpGet]
         public async Task<IActionResult> AllJobs() {
             var jobs = _jobService.GetAllJobsAsync().Result;
             if (jobs is null) {
                 return RedirectToAction(nameof(JobIndex));
             }
             return View(jobs);
         }

        [HttpPost]
        public async Task<IActionResult> RemoveJob(int jobId)
        {
            if (jobId != null && ModelState.IsValid)
            {
                var jobs = await _jobService.RemoveJobByIdAsync(jobId);
                return RedirectToAction(nameof(JobIndex));
            }
            else 
            {
                return RedirectToAction(nameof(JobIndex));
            }
        }
    }
}
