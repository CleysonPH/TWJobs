using TWJobs.Api.Candidates.Dtos;

namespace TWJobs.Api.Candidates.Services;

public interface ICandidateService
{
    ICollection<CandiateSummaryResponse> FindAll();
    CandiateDetailsResponse Create(CandidateRequest request);
    CandiateDetailsResponse FindById(int id);
    CandiateDetailsResponse UpdateById(int id, CandidateRequest request);
    void DeleteById(int id);
}