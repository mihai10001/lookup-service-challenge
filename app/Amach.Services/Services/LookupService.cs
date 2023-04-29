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

    public async Task<CreditData> Lookup(string SSN)
    {
        var debtDetails = await GetDebtDetails(SSN);
        var personalDetails = await GetPersonalDetails(SSN);
        var assessedIncomeDetails = await GetAssessedIncomeDetails(SSN);

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
