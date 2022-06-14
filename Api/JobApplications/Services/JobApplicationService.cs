using FluentValidation;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.JobApplications.Mappers;
using TWJobs.Core.Exceptions;
using TWJobs.Core.Repositories.JobApplications;

namespace TWJobs.Api.JobApplications.Services;

public class JobApplicationService : IJobApplicationService
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IJobApplicationMapper _jobApplicationMapper;
    private readonly IValidator<JobApplicationRequest> _jobApplicationRequestValidator;

    public JobApplicationService(
        IJobApplicationRepository jobApplicationRepository,
        IJobApplicationMapper jobApplicationMapper,
        IValidator<JobApplicationRequest> jobApplicationRequestValidator)
    {
        _jobApplicationRepository = jobApplicationRepository;
        _jobApplicationMapper = jobApplicationMapper;
        _jobApplicationRequestValidator = jobApplicationRequestValidator;
    }

    public JobApplicationDetailsResponse Create(JobApplicationRequest request)
    {
        _jobApplicationRequestValidator.ValidateAndThrow(request);
        var jobApplicationToCreate = _jobApplicationMapper.ToModel(request);
        var createdJobApplication = _jobApplicationRepository.Create(jobApplicationToCreate);
        return _jobApplicationMapper.ToDetailsResponse(createdJobApplication);
    }

    public void DeleteById(int id)
    {
        if (!_jobApplicationRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"JobApplication with id {id} does not exist");
        }
        _jobApplicationRepository.DeleteById(id);
    }

    public ICollection<JobApplicationSummaryResponse> FindAll()
    {
        return _jobApplicationRepository.FindAll()
            .Select(ja => _jobApplicationMapper.ToSummaryResponse(ja))
            .ToList();
    }

    public JobApplicationDetailsResponse FindById(int id)
    {
        var jobApplication = _jobApplicationRepository.FindById(id);
        if (jobApplication is null)
        {
            throw new ModelNotFoundException($"JobApplication with id {id} not found");
        }
        return _jobApplicationMapper.ToDetailsResponse(jobApplication);
    }
}