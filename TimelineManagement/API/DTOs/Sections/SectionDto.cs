using TimelineManagement.Models;

namespace TimelineManagement.DTOs.Sections;

public class SectionDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    public static implicit operator Section(SectionDto sectionDto)
    {
        return new Section
        {
            Guid = sectionDto.Guid,
            Name = sectionDto.Name
        };
    }

    public static explicit operator SectionDto(Section section)
    {
        return new SectionDto
        {
            Guid = section.Guid,
            Name = section.Name
        };
    }
}