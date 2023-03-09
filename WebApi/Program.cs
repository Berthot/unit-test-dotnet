using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
var configuration = builder.Configuration;

service.RegisterInfrastructure(configuration);
service.RegisterApplication(configuration);

service.AddMediatR(AppDomain.CurrentDomain.Load("Application"));

service.AddControllers();
service.AddFluentValidationAutoValidation();

service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

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