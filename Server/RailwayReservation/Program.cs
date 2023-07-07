using System.Reflection;
using RailwayReservation.Application;
using RailwayReservation.Infranstructure;
using RailwayReservation.Api.Filters;
using RailwayReservation.Infranstructure.Persistance;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMapping();
builder.Services.AddDbContext<RailwayReservationDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).GetTypeInfo().Assembly));
builder.Services
        //.AddMapping()
        .AddApplication()
        .AddInfanstructure(builder.Configuration);
builder.Services.AddControllers(option => option.Filters.Add<ErrorHandlingHandlingAttribute>());
//builder.Services.AddControllers();

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
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
