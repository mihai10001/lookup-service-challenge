using System.Net;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Amach.Domain.Interfaces;
using Amach.Domain.Models;
using Amach.Domain.Options;
using Amach.Domain.Exceptions;
using Microsoft.Extensions.Options;

namespace Amach.Services.Services;

public class LookupService : ILookupService
{
    private readonly CreditDataAPIOptions _creditDataAPIOptions;

    public LookupService(IOptions<CreditDataAPIOptions> options)
    {
        _creditDataAPIOptions = options.Value;
    }

    public async Task<CreditData> Lookup(string SSN)
    {
        var debtDetails = await GetDetails<DebtDetails>(_creditDataAPIOptions.BaseUrl, $"debt/{SSN}");
        var personalDetails = await GetDetails<PersonalDetails>(_creditDataAPIOptions.BaseUrl, $"personal-details/{SSN}");
        var assessedIncomeDetails = await GetDetails<AssessedIncomeDetails>(_creditDataAPIOptions.BaseUrl, $"assessed-income/{SSN}");

        return new()
        {
            FirstName = personalDetails.FirstName,
            LastName = personalDetails.LastName,
            Address = personalDetails.Address,
            AssessedIncome = assessedIncomeDetails.AssessedIncome,
            BalanceOfDebt = debtDetails.BalanceOfDebt,
            Complaints = debtDetails.Complaints
        };
    }

    private static Task<T> GetDetails<T>(string baseUrl, string pathSegment)
    {
        try
        {
            return baseUrl
                .AppendPathSegment(pathSegment)
                .GetJsonAsync<T>();
        }
        catch (FlurlHttpException ex)
        {
            if (ex.Call.Response.StatusCode is (int)HttpStatusCode.NotFound) throw new NotFoundException();
            else throw;
        }
    }
}
