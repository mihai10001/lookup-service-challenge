using System.Threading.Tasks;
using Amach.Domain.Models;

namespace Amach.Domain.Interfaces;

public interface ILookupService
{
    public Task<CreditData> Lookup(string SSN);
}
