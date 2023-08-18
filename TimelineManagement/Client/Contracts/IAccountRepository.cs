using TimelineManagement.DTOs.Account;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Contracts
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
        Task<ResponseHandler<TokenDto>> Login(LoginDto login);
        Task<ResponseHandler<RegisterDto>> Register(RegisterDto register);

    }
}
