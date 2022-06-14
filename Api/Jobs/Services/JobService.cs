using FluentValidation;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Mappers;
using TWJobs.Core.Exceptions;
using TWJobs.Core.Repositories;
using TWJobs.Core.Repositories.Jobs;

namespace TWJobs.Api.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;
    private readonly IValidator<JobRequest> _jobRequestValidator;

    public JobService(
        IJobRepository jobRepository,
        IJobMapper jobMapper,
        IValidator<JobRequest> jobRequestValidator)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
        _jobRequestValidator = jobRequestValidator;
    }

    public JobDetailsResponse Create(JobRequest request)
    {
        _jobRequestValidator.ValidateAndThrow(request);
        var jobToCreate = _jobMapper.ToModel(request);
        var createdJob = _jobRepository.Create(jobToCreate);
        return _jobMapper.ToDetailsResponse(createdJob);
    }

    public void DeleteById(int id)
    {
        if (!_jobRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Job with id {id} does not exist");
        }
        _jobRepository.DeleteById(id);
    }

    public ICollection<JobSummaryResponse> FindAll()
    {
        return _jobRepository.FindAll()
            .Select(job => _jobMapper.ToSummaryResponse(job))
            .ToList();
    }

    public PagedResponse<JobSummaryResponse> FindAll(PaginationOptions options)
    {
        var pagedResult = _jobRepository.FindAll(options);
        return _jobMapper.ToPagedSummaryResponse(pagedResult);
    }

    public JobDetailsResponse FindById(int id)
    {
        var job = _jobRepository.FindById(id);
        if (job is null)
        {
            throw new ModelNotFoundException($"Job with id {id} does not exist");
        }
        return _jobMapper.ToDetailsResponse(job);
    }

    public JobDetailsResponse UpdateById(int id, JobRequest request)
    {
        _jobRequestValidator.ValidateAndThrow(request);
        if (!_jobRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Job with id {id} does not exist");
        }
        var jobToUpdate = _jobMapper.ToModel(request);
        var updatedJob = _jobRepository.UpdateById(id, jobToUpdate);
        return _jobMapper.ToDetailsResponse(updatedJob);
    }
}
