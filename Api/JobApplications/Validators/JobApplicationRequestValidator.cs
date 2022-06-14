using FluentValidation;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Core.Repositories.Candidates;
using TWJobs.Core.Repositories.Jobs;

namespace TWJobs.Api.JobApplications.Validators;

public class JobApplicationRequestValidator : AbstractValidator<JobApplicationRequest>
{
    public JobApplicationRequestValidator(
        IJobRepository jobRepository,
        ICandidateRepository candidateRepository)
    {
        RuleFor(x => x.JobId)
            .NotEmpty()
            .Must(jobId => jobRepository.ExistsById(jobId)).WithMessage($"job não encontrado");
        RuleFor(x => x.CandidateId)
            .NotEmpty()
            .Must(candidateId => candidateRepository.ExistsById(candidateId)).WithMessage($"candidato não encontrado");
    }
}