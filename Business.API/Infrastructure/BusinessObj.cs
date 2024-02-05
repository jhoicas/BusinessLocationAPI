using CsvHelper.Configuration.Attributes;

namespace Business.API.Infrastructure
{
    public class BusinessObj
    {
        [Name("Id")]
        public int Id { get; set; }
        [Name("Description")]
        public string? Description { get; set; }
        [Name("ScheduleEnd")]
        public string? ScheduleEnd { get; set; }
        [Name("ScheduleStart")]
        public string? ScheduleStart { get; set; }
    }

}