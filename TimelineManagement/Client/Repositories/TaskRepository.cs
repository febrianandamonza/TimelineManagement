using Client.Contracts;
using Newtonsoft.Json;
using System.Text;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Repositories
{
    public class TaskRepository : GeneralRepository<TimelineManagement.Models.Task, Guid>, ITaskRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        public TaskRepository(string request = "tasks/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7230/api/")
            };
        }

        public async Task<ResponseHandler<NewDefaultTaskDto>> Create(NewDefaultTaskDto newDefaultTaskDto)
        {
            ResponseHandler<NewDefaultTaskDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newDefaultTaskDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "create-default", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<NewDefaultTaskDto>>(apiResponse);
            }
            return entityVM;
        }

    }
}
