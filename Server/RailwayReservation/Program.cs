using RailwayReservation.Application;
using RailwayReservation.Infranstructure;
using RailwayReservation.Application.Services.Authentication;
using RailwayReservation.Middleware;
using RailwayReservation.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services
        .AddApplication()
        .AddInfanstructure(builder.Configuration);
//builder.Services.AddControllers(option => option.Filters.Add<ErrorHandlingHandlingAttribute>());
builder.Services.AddControllers();

// Add services to the container.


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddlewares>();
//app.UseExceptionHandler("/error");
//app.Map("/error", (HttpContext httpContext) =>
//{
//    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//    return Results.Problem();
//});
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();

app.Run();
