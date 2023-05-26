using JobBoard.Data;
using JobBoard.Data.Entities;
using JobBoard.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Service.Response
{
    public class ResponseService : IResponseService
    {
        private readonly ApplicationDbContext _context;

        public ResponseService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateResponseAsync(ResponseCreate request)
        {
            ResponseEntity newResponse = new ResponseEntity
            {
                //                ResponseStatus = request.ResponseStatus,
                AppResponseMessage = request.AppResponseMessage,
                DateResponded = DateTime.Now
            };
            _context.Responses.Add(newResponse);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}
