using Forms.Application.Interfaces.IServices;
using Forms.Application.JwtTokens;
using Forms.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forms.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuestionOptionService, QuestionOptionService>();
        services.AddScoped<IFormService, FormService>();
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<ILikedTemplateService, LikedTemplateService>();
        services.AddScoped<IStatisticService, StatisticService>();
        
        services.AddScoped<IJwtService, JwtService>();
        services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
        services.AddJwtTokens(configuration);
        
        return services;
    }
}