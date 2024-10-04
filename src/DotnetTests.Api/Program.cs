global using DotnetTests.Database;
global using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using DotnetTests.Application;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Host.UseSerilog((ctx, lc) => 
    lc.WriteTo.Console()
);

builder.Services.AddSqlContext();
builder.Services.AddUserService();
builder.Services.AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseFastEndpoints()
    .UseSwaggerGen()
    .UseDefaultExceptionHandler();

app.Run();