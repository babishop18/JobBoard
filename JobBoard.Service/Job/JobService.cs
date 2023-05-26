using JobBoard.Data;
using JobBoard.Data.Entities;
using JobBoard.Models.Job;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Service.Job
{
    public class JobService : IJobService
    {
        private readonly string _claimId;
        private readonly ApplicationDbContext _context;
        public JobService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            _claimId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var _applicantFKey = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //   if (string.IsNullOrEmpty(_applicantFKey))
            //       throw new Exception("Attempted to build without user Id claim.");
            _context = dbContext;
        }
        public async Task<bool> CreateJobAsync(JobCreate request)
        {
            
            JobEntity newJob = new JobEntity
            {
                JobTitle = request.JobTitle,
                JobSalary = request.JobSalary,
                JobHourlyPay = request.JobHourlyPay,
                JobLocation = request.JobLocation,
                JobRequirements = request.JobRequirements,
                JobSummary = request.JobSummary,
                JobDescription = request.JobDescription,
                JobIsAvailable = request.JobIsAvailable,
                CompanyFKey = _claimId,
                DateJobPosted = DateTime.Now

        };
            _context.Jobs.Add(newJob);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> RemoveJobFromDatabaseByIdAsync(int JobId)
        {
            var jobToRemove = await _context.Jobs.Where(entity => entity.CompanyFKey == _claimId).FirstOrDefaultAsync(s => s.JobId == JobId);

            if (jobToRemove == null)
            {
                return false;
            }
            if (jobToRemove.JobApps.Count != 0)
            {
                return false;
            }
            _context.Jobs.Remove(jobToRemove);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<JobListItem>> GetJobListAsync()
        {
            IEnumerable<JobListItem> JobsToDisplay = await _context.Jobs.Where(entity => entity.CompanyFKey == _claimId)
                .Select(entity => new JobListItem
                {
                    JobTitle = entity.JobTitle,
                    JobId = entity.JobId,
                    JobSalary = entity.JobSalary,
                    JobHourlyPay = entity.JobHourlyPay,
                    JobLocation = entity.JobLocation,
                    JobSummary = entity.JobSummary,
                    DateJobPosted = entity.DateJobPosted
                }).ToListAsync();

            return JobsToDisplay;
        }

        public async Task<IEnumerable<JobListItem>> GetAllJobsAsync()
        {
            IEnumerable<JobListItem> JobsToDisplay = await _context.Jobs
                .Select(entity => new JobListItem()
                {
                    JobTitle = entity.JobTitle,
                    JobId = entity.JobId,
                    JobSalary = entity.JobSalary,
                    JobHourlyPay = entity.JobHourlyPay,
                    JobLocation = entity.JobLocation,
                    JobSummary = entity.JobSummary,
                    DateJobPosted = entity.DateJobPosted
                }).ToArrayAsync();

            return JobsToDisplay;
        }

        public async Task<JobDetail> GetJobByIdAsync(int id)
        {
            JobEntity? job = await _context.Jobs
                .Include(r => r.JobApps)
                .FirstOrDefaultAsync(r => r.JobId == id);
            if (job is null)
            {
                return null;
            }
            JobDetail jobDetail = new JobDetail()
            {
                JobTitle = job.JobTitle,
                JobSalary = job.JobSalary,
                JobHourlyPay = job.JobHourlyPay,
                JobLocation = job.JobLocation,
                JobRequirements = job.JobRequirements,
                JobSummary = job.JobSummary,
                JobDescription = job.JobDescription,
                JobIsAvailable = job.JobIsAvailable,
                DateJobPosted = job.DateJobPosted,
                JobApps = job.JobApps
            };
            return jobDetail;
        }

        public async Task<bool> UpdateJobByIdAsync(int jobId, JobUpdate update)
        {
            var jobEntity = await _context.Jobs.FirstOrDefaultAsync(c => c.JobId == jobId);
            if (jobEntity == null)
                return false;

            jobEntity.JobTitle = update.JobTitle;
            jobEntity.JobSalary = update.JobSalary;
            jobEntity.JobHourlyPay = update.JobHourlyPay;
            jobEntity.JobLocation = update.JobLocation;
            jobEntity.JobRequirements = update.JobRequirements;
            jobEntity.JobSummary = update.JobSummary;
            jobEntity.JobDescription = update.JobDescription;
            jobEntity.JobIsAvailable = update.JobIsAvailable;


            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;

        }

        public async Task<bool> RemoveJobByIdAsync(int jobId)
        {
            var jobEntity = await _context.Jobs.Where(entity => entity.CompanyFKey == _claimId).FirstOrDefaultAsync(c => c.JobId == jobId);
            if (jobEntity == null)
            {
                return false;
            }
            else if (jobEntity.JobIsAvailable == true)
            {
                jobEntity.JobIsAvailable = false;
                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            else if (!jobEntity.JobIsAvailable) 
            {
                jobEntity.JobIsAvailable = true;
                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            return false;
        }
    }
}
