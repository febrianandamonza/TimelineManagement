using Client.Contracts;
using Newtonsoft.Json;
using System.Text;
using TimelineManagement.DTOs.Account;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Repositories
{
    public class ProjectCollaboratorRepository : GeneralRepository<ProjectCollaborator, Guid>, IProjectCollaboratorRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        public ProjectCollaboratorRepository(string request = "project-collaborators/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7230/api/")
            };
        }

        public async Task<ResponseHandler<NewProjectByEmployeeDto>> Create(NewProjectByEmployeeDto newProjectByEmployeeDto)
        {
            ResponseHandler<NewProjectByEmployeeDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newProjectByEmployeeDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "create-by-email", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<NewProjectByEmployeeDto>>(apiResponse);
            }
            return entityVM;
        }

    }
}
