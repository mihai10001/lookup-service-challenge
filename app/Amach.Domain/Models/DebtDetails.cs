using System.Text.Json.Serialization;

namespace Amach.Domain.Models;

public class DebtDetails
{
    [JsonPropertyName("balance_of_debt")]
    public int BalanceOfDebt { get; set; }

    [JsonPropertyName("complaints")]
    public bool Complaints { get; set; }
}
