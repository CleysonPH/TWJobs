using FluentValidation;
using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Candidates.Mappers;
using TWJobs.Core.Exceptions;
using TWJobs.Core.Repositories.Candidates;

namespace TWJobs.Api.Candidates.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly ICandidateMapper _candidateMapper;
    private readonly IValidator<CandidateRequest> _candidateRequestValidator;

    public CandidateService(
        ICandidateRepository candidateRepository,
        ICandidateMapper candidateMapper,
        IValidator<CandidateRequest> candidateRequestValidator)
    {
        _candidateRepository = candidateRepository;
        _candidateMapper = candidateMapper;
        _candidateRequestValidator = candidateRequestValidator;
    }

    public CandiateDetailsResponse Create(CandidateRequest request)
    {
        _candidateRequestValidator.ValidateAndThrow(request);
        var candidateToCreate = _candidateMapper.ToModel(request);
        var createdCandidate = _candidateRepository.Create(candidateToCreate);
        return _candidateMapper.ToDetailsResponse(createdCandidate);
    }

    public void DeleteById(int id)
    {
        if (!_candidateRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Candidate with id {id} does not exist");
        }
        _candidateRepository.DeleteById(id);
    }

    public ICollection<CandiateSummaryResponse> FindAll()
    {
        return _candidateRepository.FindAll()
            .Select(c => _candidateMapper.ToSummaryResponse(c))
            .ToList();
    }

    public CandiateDetailsResponse FindById(int id)
    {
        var candidate = _candidateRepository.FindById(id);
        if (candidate is null)
        {
            throw new ModelNotFoundException($"Candiate with id {id} does not exist");
        }
        return _candidateMapper.ToDetailsResponse(candidate);
    }

    public CandiateDetailsResponse UpdateById(int id, CandidateRequest request)
    {
        _candidateRequestValidator.ValidateAndThrow(request);
        if (!_candidateRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Candiate with id {id} does not exist");
        }
        var candidateToUpdate = _candidateMapper.ToModel(request);
        var updatedCandidate = _candidateRepository.UpdateById(id, candidateToUpdate);
        return _candidateMapper.ToDetailsResponse(updatedCandidate);
    }
}