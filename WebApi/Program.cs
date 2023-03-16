using System.Reflection;
using Application;
using Infrastructure;
using MediatR;
using WebApi.Base;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
var configuration = builder.Configuration;
service.AddControllers();
service.AddMediatR(Assembly.GetExecutingAssembly());

// service.AddScoped<IRequestHandler<CreateBookCommand, BookCreated>, CreateBookHandler>();


// service.AddMediatR(cfg=>
    // cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


service.Configure<RouteOptions>(options => options.LowercaseUrls = true);


service.RegisterInfrastructure(configuration);
service.RegisterApplication(configuration);

// service.AddFluentValidationAutoValidation();

service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("Application"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();