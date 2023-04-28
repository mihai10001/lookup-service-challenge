using System;
using Amach.Domain.Interfaces;
using Amach.Domain.Models;
using Amach.Domain.Options;
using Microsoft.Extensions.Options;

namespace Amach.Services.Services;

public class LookupService : ILookupService
{
    private readonly CreditDataAPIOptions _creditDataAPIOptions;

    public LookupService(IOptions<CreditDataAPIOptions> options)
    {
        _creditDataAPIOptions = options.Value;
    }

    public CreditData Lookup(string SSN)
    {
        throw new NotImplementedException();
    }
}
