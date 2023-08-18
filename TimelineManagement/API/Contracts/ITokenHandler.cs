using System.Security.Claims;

namespace TimelineManagement.Contracts;

public interface ITokenHandler
{
    string? GenerateToken(IEnumerable<Claim> claims);
}