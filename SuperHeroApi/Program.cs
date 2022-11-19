using Microsoft.EntityFrameworkCore;
using SuperHeroApi.DbContexts;
using SuperHeroApi.Models.InterFAce;
using SuperHeroApi.Models.Repostriy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISuperHero, SuperHeroRepostriy>();
builder.Services.AddDbContext<SuerpHeroAccess>(
    options => options.UseSqlServer
    (builder.Configuration["ConnectionStrings:Defualt"]
    ));
builder.Services.AddAutoMapper(typeof(Program));
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
