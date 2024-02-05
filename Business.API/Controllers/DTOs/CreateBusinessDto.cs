namespace Business.API.Controllers.DTOs;
public record CreateBusinessDto(
int Id,
string Description,
string ScheduleEnd,
string ScheduleStart);