using CandidateService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateService.Infrastructure.Persistence.Configurations;

public sealed class CandidateEntityConfiguration : IEntityTypeConfiguration<CandidateEntity>
{
    public void Configure(EntityTypeBuilder<CandidateEntity> builder)
    {
        builder.ToTable("candidates");

        // Use UserId as the primary key for candidates
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("first_name");

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("last_name");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(55)
            .HasColumnName("email");

        builder.Property(x => x.Phone)
            .HasMaxLength(30)
            .HasColumnName("phone");

        builder.Property(x => x.Summary)
            .HasColumnType("text")
            .HasColumnName("summary");

        builder.Property(x => x.Location)
            .HasMaxLength(150)
            .HasColumnName("location");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");

        builder.HasMany(x => x.Skills)
                    .WithOne(x => x.Candidate)
                    .HasForeignKey(x => x.CandidateId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
}
