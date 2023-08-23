using TimelineManagement.Contracts;
using TimelineManagement.DTOs.Sections;
using TimelineManagement.Models;

namespace TimelineManagement.Services;

public class SectionService
{
    private readonly ISectionRepository _sectionRepository;
    private readonly ITaskRepository _taskRepository;

    public SectionService(ISectionRepository sectionRepository, ITaskRepository taskRepository)
    {
        _sectionRepository = sectionRepository;
        _taskRepository = taskRepository;
    }
    
   
    public IEnumerable<SectionDto> GetAll()
    {
        var sections = _sectionRepository.GetAll();
        if (!sections.Any())
        {
            return Enumerable.Empty<SectionDto>();
        }

        var SectionDtos = new List<SectionDto>();
        foreach (var section in sections)
        {
            SectionDtos.Add((SectionDto)section);
        }

        return SectionDtos;
    }

    public SectionDto? GetByGuid(Guid guid)
    {
        var section = _sectionRepository.GetByGuid(guid);
        if (section is null)
        {
            return null;
        }

        return (SectionDto)section;
    }

    public SectionDto? Create(NewSectionDto newSectionDto)
    {
        var section = _sectionRepository.Create(newSectionDto);
        if (section is null)
        {
            return null;
        }

        return (SectionDto)section;
    }

    public int Update(SectionDto SectionDto)
    {
        var section = _sectionRepository.GetByGuid(SectionDto.Guid);
        if (section is null)
        {
            return -1;
        }
        Section toUpdate = SectionDto;
        var result = _sectionRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var section = _sectionRepository.GetByGuid(guid);
        if (section is null)
        {
            return -1;
        }

        var result = _sectionRepository.Delete(section);
        return result ? 1
            : 0;
    }
}