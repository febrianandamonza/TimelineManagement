using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Contracts
{
    public interface ITaskRepository : IRepository<TimelineManagement.Models.Task, Guid>
    {
        Task<ResponseHandler<NewDefaultTaskDto>> Create(NewDefaultTaskDto newDefaultTaskDto);
    }
}
