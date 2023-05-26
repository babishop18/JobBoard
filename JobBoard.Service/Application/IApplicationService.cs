using JobBoard.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Service.Application
{
    public interface IApplicationService
    {
        Task<bool> CreateAppAsync(ApplicationCreate request);
        Task<IEnumerable<UserAppListItem>> GetUsersAppListAsync();
        Task<IEnumerable<ApplicationListItem>> GetJobsAppListAsync(int jobId);
        Task<ApplicationDetail> GetAppByIdAsync(int AppId);
    }
}
