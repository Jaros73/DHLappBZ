using DHL.Server.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;


var builder = WebApplication.CreateBuilder(args);
var authScheme = builder.Environment.IsDevelopment() ? "TestAuth" : JwtBearerDefaults.AuthenticationScheme;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddAuthentication(authScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://enterprise-oauth.company.com"; // OAuth 2.0 server v produkci
        options.Audience = "your-api";
        options.RequireHttpsMetadata = false;
    })
    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("TestAuth", null); // Pøidání fake autentizace pro vývoj

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapFallbackToFile("index.html");
app.MapControllers();

app.Run();