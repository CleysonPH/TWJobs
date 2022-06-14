using TWJobs.Api.Candidates.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.Candidates.Mappers;

public class CandidateMapper : ICandidateMapper
{
    public CandiateDetailsResponse ToDetailsResponse(Candidate candidate)
    {
        return new CandiateDetailsResponse
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Email = candidate.Email,
            BirthDate = candidate.BirthDate.ToString("yyyy-MM-dd"),
            LinkedIn = candidate.LinkedIn,
            Portifolio = candidate.Portifolio
        };
    }

    public Candidate ToModel(CandidateRequest request)
    {
        return new Candidate
        {
            Name = request.Name,
            Email = request.Email,
            BirthDate = request.BirthDate,
            LinkedIn = request.LinkedIn,
            Portifolio = request.Portifolio
        };
    }

    public CandiateSummaryResponse ToSummaryResponse(Candidate candidate)
    {
        return new CandiateSummaryResponse
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Email = candidate.Email,
            LinkedIn = candidate.LinkedIn
        };
    }
}