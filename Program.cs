using CourseraAPIProject.Services;
using CourseraAPIProject.Services.Interfaces;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBookData, BookDataLocalTest>();

builder.Services.AddControllers();

var app = builder.Build();


app.MapControllers();

app.Run();
