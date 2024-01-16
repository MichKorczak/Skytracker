using Skytracker.Api;
using Skytracker.Application;
using Skytracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(opt =>
{
    opt.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(
    opt =>
    {
        opt.GroupNameFormat = "'v'VVV";
        opt.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddApi();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

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
