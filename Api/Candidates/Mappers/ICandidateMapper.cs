using TWJobs.Api.Candidates.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.Candidates.Mappers;

public interface ICandidateMapper
{
    Candidate ToModel(CandidateRequest request);
    CandiateDetailsResponse ToDetailsResponse(Candidate candidate);
    CandiateSummaryResponse ToSummaryResponse(Candidate candidate);
}