using Microsoft.EntityFrameworkCore;
using RenterScoreAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("TempDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add health check endpoint
app.MapGet("/health", () =>
{
    return Results.Ok("ok");
})
.WithName("HealthCheck")
.WithOpenApi();

app.MapPost("/user profile", (UserProfile userProfile, AppDbContext db) =>
{
    db.UserProfiles.Add(userProfile);
    db.SaveChanges();
    return Results.Created();
})
.WithOpenApi();

app.MapGet("/user profile", (AppDbContext db) =>
{
    return Results.Ok(db.UserProfiles.ToList());
})
.WithOpenApi();

app.Run();