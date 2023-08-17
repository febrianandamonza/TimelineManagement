using TimelineManagement.Models;

namespace TimelineManagement.DTOs.Sections;

public class NewSectionDto
{
    public string Name { get; set; }

    public static implicit operator Section(NewSectionDto newSectionDto)
    {
        return new Section
        {
            Guid = new Guid(),
            Name = newSectionDto.Name
        };
    }

    public static explicit operator NewSectionDto(Section section)
    {
        return new NewSectionDto
        {
            Name = section.Name
        };
    }
}