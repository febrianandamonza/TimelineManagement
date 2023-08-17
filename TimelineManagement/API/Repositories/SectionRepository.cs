using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class SectionRepository : GeneralRepository<Section>, ISectionRepository
{
    public SectionRepository(TimelineManagementDbContext context) : base(context) { }
}