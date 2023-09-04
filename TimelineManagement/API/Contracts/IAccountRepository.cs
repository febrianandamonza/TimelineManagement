using TimelineManagement.Models;

namespace TimelineManagement.Contracts;

public interface IAccountRepository : IGeneralRepository<Account>
{
    public bool isNotExist(string value);
}