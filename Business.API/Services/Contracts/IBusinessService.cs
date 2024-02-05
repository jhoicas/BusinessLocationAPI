using Business.API.Controllers.DTOs;
using Business.API.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace Business.API.Services.Contracts
{
    public interface IBusinessService
    {
        
        public Task<List<BusinessObj>> GetAllFromCsvAsync();

        public Task<List<BusinessObj>> GetRangeSchedule();
        public Task<BusinessObj> Create(CreateBusinessDto business);


    }
}
