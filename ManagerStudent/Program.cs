using Microsoft.EntityFrameworkCore;
using ManagerStudent.Infrastructure.Data;
using ManagerStudent.Extensions;
using ManagerStudent.Core.Interfaces;
using ManagerStudent.Infrastructure.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Connection string to DBContext
builder.Services.AddDbContext<ManagerStundetContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("testConnection"),
        m => m.MigrationsAssembly("ManagerStudent.Infrastructure")
    )
);


// Add repository
builder.Services.AddInterfacesRepository();
builder.Services.AddManagerCors();


// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors(ApplicationServicesCors.NameOfPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
