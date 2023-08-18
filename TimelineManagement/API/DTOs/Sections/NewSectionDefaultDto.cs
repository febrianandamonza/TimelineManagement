using TimelineManagement.Models;

namespace TimelineManagement.DTOs.Sections;

public class NewSectionDefaultDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    public static implicit operator Section(NewSectionDefaultDto newSectionDefaultDto)
    {
        return new Section
        {
            Guid = newSectionDefaultDto.Guid,
            Name = newSectionDefaultDto.Name
        };
    }

    public static explicit operator NewSectionDefaultDto(Section section)
    {
        return new NewSectionDefaultDto
        {
            Name = section.Name
        };
    }
}