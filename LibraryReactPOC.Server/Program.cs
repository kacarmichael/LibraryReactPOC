using System;
using System.Configuration;

using LibraryReactPOC.Server.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "LocalhostOrigin",
        policy =>
        {
            policy.WithOrigins("https://localhost:5173"); 
        });
});

builder.Services.AddDbContext<LibraryDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseCors("LocalhostOrigin");

app.Run();
