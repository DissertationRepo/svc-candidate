using CandidateService.Domain.Entities.Aggregates;
using CandidateService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CandidateService.Infrastructure.Persistence.Configurations
{
    public sealed class CandidateExperienceConfiguration : IEntityTypeConfiguration<CandidateExperienceEntity>
    {
        public void Configure(EntityTypeBuilder<CandidateExperienceEntity> builder)
        {
                builder.ToTable("candidate_experiences");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id)
                    .HasColumnName("id");

                builder.Property(x => x.CandidateId)
                    .HasColumnName("candidate_id")
                    .IsRequired();

                builder.Property(x => x.Company)
                    .HasColumnName("company")
                    .HasMaxLength(200)
                    .IsRequired();

                builder.Property(x => x.Position)
                    .HasColumnName("position")
                    .HasMaxLength(150)
                    .IsRequired();

                builder.Property(x => x.Description)
                    .HasColumnName("description");

                builder.Property(x => x.StartDate)
                    .HasColumnName("start_date")
                    .IsRequired();

                builder.Property(x => x.EndDate)
                    .HasColumnName("end_date");

                builder.Property(x => x.IsCurrent)
                    .HasColumnName("is_current")
                    .IsRequired();

                builder.Property(x => x.CreatedAt)
                    .HasColumnName("created_at")
                    .IsRequired();

                builder.Property(x => x.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsRequired();
        }
    }
}
