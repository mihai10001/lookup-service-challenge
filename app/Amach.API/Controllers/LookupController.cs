using System.Threading.Tasks;
using Amach.Domain.Interfaces;
using Amach.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amach.API.Controllers;

[ApiController]
public class LookupController : Controller
{
    private readonly ILookupService _lookupService;

    public LookupController(ILookupService lookupService) => _lookupService = lookupService;

    [HttpGet]
    [Route("credit-data/{ssn}")]
    public async Task<ActionResult<CreditData>> CreditData(string SSN)
    {
        return await _lookupService.Lookup(SSN);
    }
}
