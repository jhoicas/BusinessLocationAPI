using Business.API.Infrastructure;
using CsvHelper.Configuration;

namespace Business.API.Mappers
{
    public class BusinessMap : ClassMap<BusinessObj>
    {
        public BusinessMap()
        {
            Map(x => x.Id).Name("Id");
            Map(x => x.Description).Name("Description");
            Map(x => x.ScheduleEnd).Name("ScheduleEnd");
            Map(x => x.ScheduleStart).Name("ScheduleStart");
        }
    }
}
