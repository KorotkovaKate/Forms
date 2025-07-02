namespace Forms.Application.DTOs.CommentDTOs;

public class AddCommentDto
{
    public uint? UserId { get; set; }
    public uint? TemplateId { get; set; }
    public string Text { get; set; } 
}