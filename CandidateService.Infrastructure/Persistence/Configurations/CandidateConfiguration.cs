using CandidateService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateService.Infrastructure.Persistence.Configurations;

public sealed class CandidateEntityConfiguration : IEntityTypeConfiguration<CandidateEntity>
{
    public void Configure(EntityTypeBuilder<CandidateEntity> builder)
    {
        builder.ToTable("candidates");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("full_name");

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
    }
}
