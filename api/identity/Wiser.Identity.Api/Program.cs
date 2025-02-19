using Wiser.Common.Extensions;
using Wiser.Identity.Api.Controllers;
using Wiser.Identity.CQRS.Handlers;
using Wiser.Identity.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddCQRSServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiSwaggerDocument(builder.Configuration);
builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddApiCors(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsNSwag())
{
    app.MigrateDatabase();
}

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseApiCors();
app.UseHttpsRedirection();
app.UseApiEndpoints();

app.Run();
