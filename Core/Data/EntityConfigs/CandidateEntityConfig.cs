using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWJobs.Core.Models;

namespace TWJobs.Core.Data.EntityConfigs;

public class CandidateEntityConfig : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable("Candidates");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.BirthDate)
            .IsRequired();

        builder.Property(c => c.LinkedIn)
            .HasMaxLength(100);

        builder.Property(c => c.Portifolio)
            .HasMaxLength(100);
    }
}