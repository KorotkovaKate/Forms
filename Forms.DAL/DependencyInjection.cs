using Forms.Application.Interfaces.ISecurity;
using Forms.Core.Interfaces.IRepositories;
using Forms.DAL.Repositories;
using Forms.DAL.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forms.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FormDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(FormDbContext)));
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITemplateRepository, TemplateRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ILikedTemplateRepository, LikedTemplateRepository>();
        services.AddScoped<IStatisticRepository, StatisticRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        
        return services;
    }
}