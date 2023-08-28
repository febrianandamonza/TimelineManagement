using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class TaskHistoryRepository : GeneralRepository<TaskHistory>, ITaskHistoryRepository
{
    public TaskHistoryRepository(TimelineManagementDbContext context) : base(context) { }
}