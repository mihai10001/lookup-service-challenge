using Amach.Domain.Models;

namespace Amach.Domain.Interfaces;

public interface ILookupService
{
    public CreditData Lookup(string SSN);
}
