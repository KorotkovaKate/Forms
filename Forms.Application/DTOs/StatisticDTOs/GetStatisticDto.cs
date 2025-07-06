namespace Forms.Application.DTOs;

public class GetStatisticDto
{
    public uint StatisticId { get; set; }
    public string MostCommonAnswer  { get; set; }
    public int AnswerFrequencyInPercent { get; set; }
    public string TemplateTitle { get; set; }
    public string? ImageUrl { get; set; }
    public string QuestionTitle { get; set; }
}