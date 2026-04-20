using CandidateService.Api.ModelValidators;
using CandidateService.Infrastructure;
using CandidateService.Infrastructure.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddValidatorsFromAssemblyContaining<NewCandidateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddCandidateSkillValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(
    typeof(CandidateService.Api.Mappings.NewCandidateMapping).Assembly,
    typeof(CandidateService.Infrastructure.Mappings.DomainCandidateMapping).Assembly,
    typeof(CandidateService.Api.Mappings.AddCandidateSkillMapping).Assembly,
    typeof(CandidateService.Infrastructure.Mappings.DomainCandidateSkillMapping).Assembly
    );

var conString = builder.Configuration.GetConnectionString("CandidateDB") ??
     throw new InvalidOperationException("Connection string 'CandidateDB'" +
    " not found.");
builder.Services.AddDbContext<CandidateDbContext>(options =>
    options.UseNpgsql(conString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
