using System.Text.Json.Serialization;

namespace Amach.Domain.Models;

public class PersonalDetails
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }
}
