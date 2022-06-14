using TWJobs.Core.Data.Contexts;
using TWJobs.Core.Models;

namespace TWJobs.Core.Repositories.Candidates;

public class CandidateRepository : ICandidateRepository
{
    private readonly TWJobsDbContext _context;

    public CandidateRepository(TWJobsDbContext context)
    {
        _context = context;
    }

    public Candidate Create(Candidate model)
    {
        _context.Candidates.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var candidate = _context.Candidates.Find(id);
        if (candidate is not null)
        {
            _context.Candidates.Remove(candidate);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Candidates.Any(c => c.Id == id);
    }

    public ICollection<Candidate> FindAll()
    {
        return _context.Candidates.ToList();
    }

    public Candidate? FindById(int id)
    {
        return _context.Candidates.Find(id);
    }

    public Candidate UpdateById(int id, Candidate model)
    {
        model.Id = id;
        _context.Candidates.Update(model);
        _context.SaveChanges();
        return model;
    }
}