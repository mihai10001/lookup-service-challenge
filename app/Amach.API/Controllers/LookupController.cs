using System.Threading.Tasks;
using Amach.API.DTOs;
using Amach.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Amach.API.Controllers;

[ApiController]
public class LookupController : Controller
{
    private readonly ILookupService _lookupService;

    public LookupController(ILookupService lookupService) => _lookupService = lookupService;

    [HttpGet]
    [Route("credit-data/{ssn}")]
    public async Task<ActionResult<CreditDataDTO>> CreditData(string SSN)
    {
        var creditData = await _lookupService.Lookup(SSN);
        var dto = CreditDataDTO.MapFrom(creditData);
        return Ok(dto);
    }
}
