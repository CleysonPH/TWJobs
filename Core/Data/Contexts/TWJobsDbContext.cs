using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.EntityConfigs;
using TWJobs.Core.Models;

namespace TWJobs.Core.Data.Contexts;

public class TWJobsDbContext : DbContext
{
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=Localhost;Database=TWJobs;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new JobEntityConfig());
        builder.ApplyConfiguration(new CandidateEntityConfig());
        builder.ApplyConfiguration(new JobApplicationEntityConfig());
    }
}