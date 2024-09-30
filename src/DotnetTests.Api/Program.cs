global using DotnetTests.Database;
global using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => 
    lc.WriteTo.Console()
);

builder.Services.AddSqlContext();
builder.Services.AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints()
    .UseSwaggerGen()
    .UseDefaultExceptionHandler();

app.Run();