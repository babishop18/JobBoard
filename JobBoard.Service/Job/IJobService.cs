using JobBoard.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Service.Job
{
    public interface IJobService
    {
        Task<bool> CreateJobAsync(JobCreate request);
        Task<bool> RemoveJobFromDatabaseByIdAsync(int JobId);
        Task<IEnumerable<JobListItem>> GetJobListAsync();
        Task<bool> UpdateJobByIdAsync(int jobId, JobUpdate update);
        Task<IEnumerable<JobListItem>> GetAllJobsAsync();
        Task<JobDetail> GetJobByIdAsync(int id);
        Task<bool> RemoveJobByIdAsync(int jobId);
    }
}
