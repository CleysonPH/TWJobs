namespace TWJobs.Core.Models;

public class JobApplication
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int CandidateId { get; set; }

    public Job Job { get; set; } = null!;
    public Candidate Candidate { get; set; } = null!;
}