using AutoMapper;
using SocialMedia.Abstraction;
using SocialMedia.Helpers;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;
using SocialMedia.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddSingleton<PersianDateStringToDateMapper>();
builder.Services.AddSingleton<IScoringAlgorithm, ScoringAlgorithm>();
builder.Services.AddSingleton<IFindingVerticesWithDistance<int, User>, FindingVerticesWithDistance<int, User>>();
builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<string, DateTime>().ConvertUsing<PersianDateStringToDateMapper>();
    config.CreateMap<UserDto, User>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();