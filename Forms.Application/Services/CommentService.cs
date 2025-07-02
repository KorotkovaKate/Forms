using Forms.Application.DTOs;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class CommentService(ICommentRepository repository): ICommentService
{
    public async Task AddComment(AddCommentDto addCommentDto)
    {
        if (addCommentDto == null) {throw new ArgumentException("Incorrect comment");}
        var comment = CommentMapping.AddComment(addCommentDto);
        await repository.AddComment(comment);
    }

    public async Task DeleteComment(uint? commentId)
    {
        var comment = await GetCommentById(commentId);
        if (comment == null) {throw new ArgumentException("Incorrect comment");}
        await repository.DeleteComment(comment);
    }

    public Task<Comment?> GetCommentById(uint? commentId)
    {
        if  (commentId == null) {throw new ArgumentException("Incorrect commentId");}
        return repository.GetCommentById(commentId.Value);
    }

    public async Task UpdateComment(UpdateCommentDto updateCommentDto)
    {
        if(updateCommentDto.Id == null) throw new Exception("Message cant be found");
        if(string.IsNullOrWhiteSpace(updateCommentDto.Text)) throw new Exception("Text to edit cant be empty");
        await repository.UpdateComment(updateCommentDto.Id.Value, updateCommentDto.Text);
    }

    public Task<List<Comment>> GetAllCommentsByTemplateId(uint? templateId)
    {
        if  (templateId == null) {throw new ArgumentException("Incorrect templateId");}
        return repository.GetAllCommentsByTemplateId(templateId.Value);
    }
}