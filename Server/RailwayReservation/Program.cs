using RailwayReservation.Application;
using RailwayReservation.Infranstructure;
using RailwayReservation.Application.Services.Authentication;


var builder = WebApplication.CreateBuilder(args);

builder.Services
        .AddApplication()
        .AddInfanstructure(builder.Configuration);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
