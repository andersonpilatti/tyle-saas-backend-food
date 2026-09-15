using System.Text.Json.Serialization;
using Tyle.Packages.Auth.Extensions;
using Tyle.Packages.Results.AspNetCore.Extensions;
using Tyle.SaaS.Backend.Food.Application;
using Tyle.SaaS.Backend.Food.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddTyleSqlServerConflictHandling().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddTyleAuthentication(builder.Configuration);
builder.Services.AddFoodApplication().AddFoodInfrastructure(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("/health");
app.MapControllers();
app.MapGet("/", (IHostEnvironment environment) =>
{
    return Results.Redirect(environment.IsDevelopment() ? "/swagger" : "/api/home");
});

await app.RunAsync();
