namespace TWJobs.Core.Models;

public class Candidate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string? LinkedIn { get; set; }
    public string? Portifolio { get; set; }

    public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}