using System.Security.Cryptography;
using Microsoft.VisualBasic.CompilerServices;
using System.Reflection.PortableExecutable;
using cualquirCosa.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Prog31105Context>(options=> options.UseNpgsql(builder.Configuration.GetConnectionString("conexionDB")));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);	

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors=>{
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
