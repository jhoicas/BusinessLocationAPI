using Business.API.Controllers.DTOs;
using Business.API.Infrastructure;
using Business.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Business.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessLocationController : ControllerBase
{
    private readonly ILogger<BusinessLocationController> _logger;
    private readonly IBusinessService _businessService;

    public BusinessLocationController(ILogger<BusinessLocationController> logger, IBusinessService businessService)
    {
        _logger = logger;
        _businessService = businessService;
    }
    

          [HttpGet("getAll")]
    public async Task<ActionResult<List<BusinessObj>>> GetAllBusiness()
    {
        return await _businessService.GetAllFromCsvAsync();
    }
    [HttpGet("range")]
    public async Task<ActionResult<List<BusinessObj>>> GetRangeBusiness()
    {
        return await _businessService.GetRangeSchedule();
    }

    [HttpPost]
    public async Task<ActionResult<BusinessObj>> Create(CreateBusinessDto business)
    {
        var businessObj = await _businessService.Create(business);
        return Ok(businessObj);
    }
}