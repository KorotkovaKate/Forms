namespace Forms.Application.DTOs;

public class GetAllTemplatesForAdminDto
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public int CountOfLikes { get; set; }
}