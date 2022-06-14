namespace TWJobs.Api.Candidates.Dtos;

public class CandidateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string? LinkedIn { get; set; }
    public string? Portifolio { get; set; }
}