using Forms.Application;
using Forms.DAL;
using Forms.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services
    .AddApplication(configuration)
    .AddDal(configuration);

services.AddSwaggerGen();
services.AddEndpointsApiExplorer();

services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddProblemDetails();
services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();