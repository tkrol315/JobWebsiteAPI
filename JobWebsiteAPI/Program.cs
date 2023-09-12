using FluentValidation;
using FluentValidation.AspNetCore;
using JobWebsiteAPI;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Middleware;
using JobWebsiteAPI.Models.AccountModels;
using JobWebsiteAPI.Models.JobOffer;
using JobWebsiteAPI.Models.Validators;
using JobWebsiteAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);

builder.Services.AddDbContext<JobWebsiteDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobWebsiteConnectionString"));
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
    options.DefaultScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = jwtSettings.JwtIssuer,
        ValidAudience = jwtSettings.JwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.JwtKey)),
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IJobOfferService, JobOfferService>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IContractTypeSerivce, ContractTypeService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
builder.Services.AddScoped<IValidator<RegisterCompanyAccountDto>, RegisterCompanyAccountDtoValidator>();
builder.Services.AddScoped<IValidator<RegisterPersonalAccountDto>, RegisterPersonalAccountDtoValidator>();
builder.Services.AddScoped<IValidator<CreateJobOfferDto>, CreateJobOfferDtoValidator>();
builder.Services.AddScoped<Seeder>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
