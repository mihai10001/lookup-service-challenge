using Amach.Domain.Models;

namespace Amach.API.DTOs;

public class CreditDataDTO
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string address { get; set; }
    public int assessed_income { get; set; }
    public int balance_of_debt { get; set; }
    public bool complaints { get; set; }

    public CreditDataDTO MapFromModel(CreditData model)
    {
        return new()
        {
            first_name = model.FirstName,
            last_name = model.LastName,
            address = model.Address,
            assessed_income = model.AssessedIncome,
            balance_of_debt = model.BalanceOfDebt,
            complaints = model.Complaints
        };
    }
}
