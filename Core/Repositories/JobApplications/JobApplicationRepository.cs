using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.Contexts;
using TWJobs.Core.Models;

namespace TWJobs.Core.Repositories.JobApplications;

public class JobApplicationRepository : IJobApplicationRepository
{
    private readonly TWJobsDbContext _context;

    public JobApplicationRepository(TWJobsDbContext context)
    {
        _context = context;
    }

    public JobApplication Create(JobApplication model)
    {
        _context.JobApplications.Add(model);
        _context.SaveChanges();
        var jobApplication = FindById(model.Id);
        if (jobApplication is null)
        {
            throw new Exception("JobApplication not created");
        }
        return jobApplication;
    }

    public void DeleteById(int id)
    {
        var jobApplication = _context.JobApplications.Find(id);
        if (jobApplication is not null)
        {
            _context.JobApplications.Remove(jobApplication);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.JobApplications.Any(j => j.Id == id);
    }

    public ICollection<JobApplication> FindAll()
    {
        return _context.JobApplications
            .Include(ja => ja.Job)
            .Include(ja => ja.Candidate)
            .ToList();
    }

    public JobApplication? FindById(int id)
    {
        return _context.JobApplications
            .Include(ja => ja.Job)
            .Include(ja => ja.Candidate)
            .FirstOrDefault(ja => ja.Id == id);
    }

    public JobApplication UpdateById(int id, JobApplication model)
    {
        model.Id = id;
        _context.JobApplications.Update(model);
        _context.SaveChanges();
        return model;
    }
}