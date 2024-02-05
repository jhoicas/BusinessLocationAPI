using Business.API.Controllers.DTOs;
using Business.API.Infrastructure;
using Business.API.Repositories.Contracts;

namespace Business.API.Services.Contracts
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repo;
        public BusinessService(IBusinessRepository businessRepo)
        {
            _repo = businessRepo;
        }
        public async Task<BusinessObj> Create(CreateBusinessDto business)
        {
            return await _repo.WriteCsvAsync(business);
        }

        public async Task<List<BusinessObj>> GetAllFromCsvAsync()
        {
            return await _repo.GetAllBussinessFromCsvAsync();
        }

        public async Task<List<BusinessObj>> GetRangeSchedule()
        {
            return await _repo.GetRangeScheduleFromCsvAsync();
        }
    }
}
