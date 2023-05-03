using System.Text.Json.Serialization;

namespace Amach.Domain.Models;

public class AssessedIncomeDetails
{
    [JsonPropertyName("assessed_income")]
    public int AssessedIncome { get; set; }
}
