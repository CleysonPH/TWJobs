namespace TWJobs.Api.Jobs.Dtos;

public class JobRequest
{
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public ICollection<String> Requirements { get; set; } = new List<String>();
}