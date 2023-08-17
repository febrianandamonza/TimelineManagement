using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Repositories;

public class TaskCommentRepository : GeneralRepository<TaskComment>, ITaskCommentRepository
{
    public TaskCommentRepository(TimelineManagementDbContext context) : base(context) { }
}