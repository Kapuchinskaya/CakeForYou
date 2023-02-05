using CakeForYou;
using CakeForYou.Application;
using CakeForYou.Infrastructure;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);


// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>()); v1

var app = builder.Build();

// app.UseMiddleware<ErrorHandlingMiddleware>(); //v2
app.UseExceptionHandler("/error"); // v3

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();