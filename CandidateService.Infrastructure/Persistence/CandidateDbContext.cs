using CandidateService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateService.Infrastructure.Persistence;

public sealed class CandidateDbContext : DbContext
{
    public CandidateDbContext(DbContextOptions<CandidateDbContext> options)
        : base(options)
    {
    }

    public DbSet<CandidateEntity> Candidates => Set<CandidateEntity>();
    public DbSet<CandidateSkillEntity> CandidateSkills => Set<CandidateSkillEntity>();
    public DbSet<CandidateExperienceEntity> CandidateExperiences => Set<CandidateExperienceEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CandidateDbContext).Assembly);
    }
}
