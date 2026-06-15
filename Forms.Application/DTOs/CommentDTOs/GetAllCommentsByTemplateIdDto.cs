namespace Forms.Application.DTOs.CommentDTOs;

public class GetAllCommentsByTemplateIdDto
{
    public uint CommentId { get; set; }
    public string CommentText { get; set; }
    public DateTime PublishTime { get; set; }
    public string UserName { get; set; }
}