using CandidateService.Api.ModelValidators;
using CandidateService.Infrastructure;
using CandidateService.Infrastructure.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<NewCandidateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddCandidateSkillValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddCandidateExperienceValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(
    typeof(CandidateService.Api.Mappings.NewCandidateMapping).Assembly,
    typeof(CandidateService.Infrastructure.Mappings.DomainCandidateMapping).Assembly,
    typeof(CandidateService.Api.Mappings.AddCandidateSkillMapping).Assembly,
    typeof(CandidateService.Infrastructure.Mappings.DomainCandidateSkillMapping).Assembly, 
    typeof(CandidateService.Api.Mappings.AddCandidateExperienceMapping).Assembly,
    typeof(CandidateService.Infrastructure.Mappings.DomainCandiateExperienceMapping).Assembly,
    typeof(CandidateService.Api.Mappings.ExperiencesResponseMapping).Assembly,
    typeof(CandidateService.Api.Mappings.SkillsResponseMapping).Assembly,
    typeof(CandidateService.Api.Mappings.DomainCandidateMapping).Assembly
    );

var conString = builder.Configuration.GetConnectionString("CandidateDB") ??
     throw new InvalidOperationException("Connection string 'CandidateDB'" +
    " not found.");
builder.Services.AddDbContext<CandidateDbContext>(options =>
    options.UseNpgsql(conString));

builder.Services.AddControllers();

// JWT configuration
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtKey = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key not configured");
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtSection["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

// Swagger with Bearer support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Must add authentication middleware before authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
