using TWJobs.Api.Common.Dtos;

namespace TWJobs.Api.Candidates.Dtos;

public class CandiateSummaryResponse : ResourceResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? LinkedIn { get; set; }
}