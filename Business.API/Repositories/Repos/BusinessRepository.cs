using Business.API.Controllers.DTOs;
using Business.API.Infrastructure;
using Business.API.Repositories.Contracts;
using System.Globalization;
using System.Text;
using CsvHelper;
using Business.API.Mappers;
using Business.API.Utils;
using System.Reflection.PortableExecutable;

namespace Business.API.Repositories.Repos
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _pathFile;

        public BusinessRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _pathFile = Path.GetFullPath(_configuration["AppSettings:pathFile"]);
        }

        public async Task<List<BusinessObj>> GetRangeScheduleFromCsvAsync()
        {
            List<BusinessObj> businessLocationAux = new List<BusinessObj>();

            var businessLocation =getAllBusiness();

            businessLocationAux = businessLocation.Where(x => DateTimeHelper.CompareSchedule(x.ScheduleStart, x.ScheduleEnd)).ToList();
            
            return (List<BusinessObj>)await Task.Run(() => businessLocationAux);
        }

        public List<BusinessObj> getAllBusiness()
        {
            List<BusinessObj> businessLocation = new List<BusinessObj>();
            try
            {
                using (var reader = new StreamReader(_pathFile, Encoding.Default))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<BusinessMap>();
                    businessLocation = csv.GetRecords<BusinessObj>().ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return businessLocation;
        }

        public async Task<List<BusinessObj>> GetAllBussinessFromCsvAsync()
        {
            return await Task.Run(() => getAllBusiness());
        }

        public async Task<BusinessObj> WriteCsvAsync(CreateBusinessDto business)
        {
            List<BusinessObj> businessLocation = new List<BusinessObj>();
            businessLocation = await GetRangeScheduleFromCsvAsync();
            businessLocation.Add(new BusinessObj { Id = businessLocation.Count + 1, Description = business.Description, ScheduleStart = business.ScheduleStart, ScheduleEnd = business.ScheduleEnd });

            using (StreamWriter sw = new StreamWriter(_pathFile, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<BusinessObj>();
                cw.NextRecord();
                foreach (BusinessObj stu in businessLocation)
                {
                    cw.WriteRecord(stu);
                    cw.NextRecord();
                }
            }
            return await Task.Run(() => businessLocation.Last());
        }
    }
}