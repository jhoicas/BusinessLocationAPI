using Business.API.Controllers.DTOs;
using Business.API.Infrastructure;

namespace Business.API.Repositories.Contracts
{
    public interface IBusinessRepository
    {
        public Task<List<BusinessObj>> GetAllBussinessFromCsvAsync();
        public Task<List<BusinessObj>> GetRangeScheduleFromCsvAsync();
        public Task<BusinessObj> WriteCsvAsync(CreateBusinessDto business);
    }
}
