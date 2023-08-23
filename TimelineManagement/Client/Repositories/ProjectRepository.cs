using Client.Contracts;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using TimelineManagement.DTOs.Account;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Repositories
{
    public class ProjectRepository : GeneralRepository<Project, Guid>, IProjectRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        public ProjectRepository(string request = "projects/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7230/api/")
            };
        }

        public async Task<ResponseHandler<NewDefaultProjectDto>> Create(NewDefaultProjectDto newDefaultProjectDto)
        {
            ResponseHandler<NewDefaultProjectDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newDefaultProjectDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "create-default", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<NewDefaultProjectDto>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<DetailProject>> GetDetail(Guid id)
        {
            ResponseHandler<DetailProject> entityVm = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            using (var response = httpClient.GetAsync(request + id).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVm = JsonConvert.DeserializeObject<ResponseHandler<DetailProject>>(apiResponse);
            }

            return entityVm;
        }

    }
}
