namespace Forms.Application.DTOs.StatisticDTOs;

public class GetStatisticDto
{
    public uint StatisticId { get; set; }
    public string MostCommonAnswer  { get; set; }
    public int AnswerFrequencyInPercent { get; set; }
    public uint TemplateId { get; set; }
    public uint QuestionId { get; set; }
}