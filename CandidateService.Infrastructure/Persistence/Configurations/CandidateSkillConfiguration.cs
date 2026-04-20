using CandidateService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CandidateService.Infrastructure.Persistence.Configurations
{
    public class CandidateSkillConfiguration : IEntityTypeConfiguration<CandidateSkillEntity>
    {
        public void Configure(EntityTypeBuilder<CandidateSkillEntity> builder)
        {
            
                builder.ToTable("candidate_skills");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id)
                    .HasColumnName("id");

                builder.Property(x => x.CandidateId)
                    .HasColumnName("candidate_id")
                    .IsRequired();

                builder.Property(x => x.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsRequired();

                builder.Property(x => x.Level)
                    .HasColumnName("level")
                    .HasMaxLength(50);

                builder.Property(x => x.YearsOfExperience)
                    .HasColumnName("years_of_experience");

                builder.Property(x => x.CreatedAt)
                    .HasColumnName("created_at")
                    .IsRequired();
            
        }
    }
}
