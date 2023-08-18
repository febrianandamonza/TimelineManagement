using Client.Contracts;
using Newtonsoft.Json;
using System.Text;
using TimelineManagement.DTOs.Account;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Repositories
{
    public class AccountRepository : GeneralRepository<Account, Guid>, IAccountRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        public AccountRepository(string request = "accounts/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7230/api/")
            };
        }
        
        public async Task<ResponseHandler<TokenDto>> Login(LoginDto entity)
        {
            ResponseHandler<TokenDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Login", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<TokenDto>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<RegisterDto>> Register(RegisterDto register)
        {
            ResponseHandler<RegisterDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Register", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<RegisterDto>>(apiResponse);
            }
            return entityVM;
        }
    }
}
