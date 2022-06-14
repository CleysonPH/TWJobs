using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Services;
using TWJobs.Core.Repositories;

namespace TWJobs.Api.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IAssembler<JobDetailsResponse> _jobDetailsAssembler;
    private readonly IPagedAssembler<JobSummaryResponse> _jobSummaryPagedAssembler;

    public JobController(
        IJobService jobService,
        IAssembler<JobDetailsResponse> jobDetailsAssembler,
        IPagedAssembler<JobSummaryResponse> jobSummaryPagedAssembler)
    {
        _jobService = jobService;
        _jobDetailsAssembler = jobDetailsAssembler;
        _jobSummaryPagedAssembler = jobSummaryPagedAssembler;
    }

    [HttpGet(Name = "FindAllJobs")]
    public IActionResult FindAll([FromQuery] PaginationOptions options)
    {
        var validatedOptions = new PaginationOptions(options.PageNumber, options.PageSize);
        var jobs = _jobService.FindAll(validatedOptions);
        return Ok(_jobSummaryPagedAssembler.ToPagedResource(jobs, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var job = _jobService.FindById(id);
        return Ok(_jobDetailsAssembler.ToResource(job, HttpContext));
    }

    [HttpPost(Name = "CreateJob")]
    public IActionResult Create([FromBody] JobRequest request)
    {
        var job = _jobService.Create(request);
        return CreatedAtAction(
            nameof(FindById),
            new { id = job.Id },
            _jobDetailsAssembler.ToResource(job, HttpContext)
        );
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest request)
    {
        var job = _jobService.UpdateById(id, request);
        return Ok(_jobDetailsAssembler.ToResource(job, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}
