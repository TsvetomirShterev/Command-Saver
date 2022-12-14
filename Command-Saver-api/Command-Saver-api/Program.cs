using AutoMapper;
using Command_Saver_data;
using Command_Saver_data.Commands;
using Command_Saver_data.Queries;
using Command_Saver_service.Profiles;
using Command_Saver_service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(config =>
{
    config.AddProfile(new CommandsProfile());
    config.AddProfile(new PlatformsProfile());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder
    .Services
    .AddDbContext<CommandSaverDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICommandQueries, CommandQueries>();

builder.Services.AddScoped<ICommandCommands, CommandCommands>();

builder.Services.AddScoped<ICommandService, CommandService>();

builder.Services.AddScoped<IPlatformCommands, PlatformCommands>();

builder.Services.AddScoped<IPlatformQueries, PlatformQueries>();

builder.Services.AddScoped<IPlatformService, PlatformService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
