using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.JobApplications.Mappers;
using TWJobs.Api.JobApplications.Services;

namespace TWJobs.Api.JobApplications.Controllers;

[ApiController]
[Route("api/job-applications")]
public class JobApplicationController : ControllerBase
{
    private readonly IJobApplicationService _jobApplicationService;
    private readonly IAssembler<JobApplicationSummaryResponse> _jobApplicationSummaryAssembler;
    private readonly IAssembler<JobApplicationDetailsResponse> _jobApplicationDetailsAssembler;

    public JobApplicationController(
        IJobApplicationService jobApplicationService,
        IAssembler<JobApplicationSummaryResponse> jobApplicationSummaryAssembler,
        IAssembler<JobApplicationDetailsResponse> jobApplicationDetailsAssembler)
    {
        _jobApplicationService = jobApplicationService;
        _jobApplicationSummaryAssembler = jobApplicationSummaryAssembler;
        _jobApplicationDetailsAssembler = jobApplicationDetailsAssembler;
    }

    [HttpPost(Name = "CreateJobApplication")]
    public IActionResult Create([FromBody] JobApplicationRequest request)
    {
        var jobApplication = _jobApplicationService.Create(request);
        return CreatedAtAction(
            nameof(FindById),
            new { id = jobApplication.Id },
            _jobApplicationDetailsAssembler.ToResource(jobApplication, HttpContext));
    }

    [HttpGet(Name = "FindAllJobApplications")]
    public IActionResult FindAll()
    {
        var jobApplications = _jobApplicationService.FindAll();
        return Ok(_jobApplicationSummaryAssembler.ToResourceCollection(jobApplications, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobApplicationById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var jobApplication = _jobApplicationService.FindById(id);
        return Ok(_jobApplicationDetailsAssembler.ToResource(jobApplication, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobApplicationById")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobApplicationService.DeleteById(id);
        return NoContent();
    }
}
