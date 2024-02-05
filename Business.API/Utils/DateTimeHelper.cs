
namespace Business.API.Utils
{
    public static class DateTimeHelper
    {
        public static bool CompareSchedule(string _scheduleStart, string _scheduleEnd)
        {
            var ScheduleStart = new DateTime(); 
            var ScheduleEnd = new DateTime();  
            var initialTime = DateTime.ParseExact("10:00", "H:mm", null, System.Globalization.DateTimeStyles.None);
            var endTime = DateTime.ParseExact("13:00", "H:mm", null, System.Globalization.DateTimeStyles.None);
            DateTime.TryParseExact(_scheduleStart, "H:mm", null, System.Globalization.DateTimeStyles.None, out ScheduleStart);
            DateTime.TryParseExact(_scheduleEnd, "H:mm", null, System.Globalization.DateTimeStyles.None, out ScheduleEnd);

            var response = (ScheduleStart >= initialTime && ScheduleEnd <= endTime);
            return response;
        }
    }
}
