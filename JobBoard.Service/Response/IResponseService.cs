using JobBoard.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Service.Response
{
    public interface IResponseService
    {
        Task<bool> CreateResponseAsync(ResponseCreate request);
    }
}
