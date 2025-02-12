using CourseraAPIProject.Middleware;
using CourseraAPIProject.Services;
using CourseraAPIProject.Services.Interfaces;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBookData, BookDataLocalTest>();
builder.Services.AddSingleton<ITrafficTracker, TrafficTrackerLocalTest>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<TrafficTrackerMiddleware>();
app.MapControllers();
app.Run();
