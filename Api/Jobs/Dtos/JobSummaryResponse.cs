using TWJobs.Api.Common.Dtos;

namespace TWJobs.Api.Jobs.Dtos;

public class JobSummaryResponse : ResourceResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}