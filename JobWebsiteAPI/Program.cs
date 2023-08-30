using FluentValidation;
using FluentValidation.AspNetCore;
using JobWebsiteAPI;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models;
using JobWebsiteAPI.Models.Validators;
using JobWebsiteAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<JobWebsiteDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobWebsiteConnectionString"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IPasswordHasher<Account>,PasswordHasher<Account>>();
builder.Services.AddScoped<IValidator<RegisterCompanyAccountDto>,RegisterCompanyAccountDtoValidator>();
builder.Services.AddScoped<IValidator<RegisterPersonalAccountDto>, RegisterPersonalAccountDtoValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
