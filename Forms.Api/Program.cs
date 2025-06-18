using Forms.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<FormDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(FormDbContext)));
});
var app = builder.Build();
app.Run();