using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using UnhingedApi.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

builder.AddStandardServices();
builder.AddCustomServices();
builder.AddAuthenticationServices();
builder.AddAuthorizationServices();
builder.AddHealthCheckServices();
builder.AddVersioningServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
}).AllowAnonymous();

app.MapHealthChecksUI().AllowAnonymous();

app.Run();
