using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
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

    private Task<PersonalDetails> GetPersonalDetails(string SSN)
    {
        return _creditDataAPIOptions
            .BaseUrl
            .AppendPathSegment("personal-details")
            .AppendPathSegment(SSN)
            .GetJsonAsync<PersonalDetails>();
    }

    private Task<AssessedIncomeDetails> GetAssessedIncomeDetails(string SSN)
    {
        return _creditDataAPIOptions
            .BaseUrl
            .AppendPathSegment("assessed-income")
            .AppendPathSegment(SSN)
            .GetJsonAsync<AssessedIncomeDetails>();
    }

    private Task<DebtDetails> GetDebtDetails(string SSN)
    {
        return _creditDataAPIOptions
            .BaseUrl
            .AppendPathSegment("debt")
            .AppendPathSegment(SSN)
            .GetJsonAsync<DebtDetails>();
    }
}
