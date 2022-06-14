using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWJobs.Core.Models;

namespace TWJobs.Core.Data.EntityConfigs;

public class JobApplicationEntityConfig : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.ToTable("JobApplications");

        builder.HasKey(j => j.Id);

        builder.Property(j => j.JobId)
            .IsRequired();

        builder.Property(j => j.CandidateId)
            .IsRequired();

        builder.HasOne(j => j.Job)
            .WithMany(j => j.JobApplications)
            .HasForeignKey(j => j.JobId);

        builder.HasOne(j => j.Candidate)
            .WithMany(j => j.JobApplications)
            .HasForeignKey(j => j.CandidateId);
    }
}