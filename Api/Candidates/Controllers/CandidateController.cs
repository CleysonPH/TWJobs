using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Candidates.Services;
using TWJobs.Api.Common.Assemblers;

namespace TWJobs.Api.Candidates.Controllers;

[ApiController]
[Route("api/candidates")]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;
    private readonly IAssembler<CandiateSummaryResponse> _candidateSummaryAssembler;
    private readonly IAssembler<CandiateDetailsResponse> _candidateDetailsAssembler;

    public CandidateController(
        ICandidateService candidateService,
        IAssembler<CandiateSummaryResponse> candidateSummaryAssembler,
        IAssembler<CandiateDetailsResponse> candidateDetailsAssembler)
    {
        _candidateService = candidateService;
        _candidateSummaryAssembler = candidateSummaryAssembler;
        _candidateDetailsAssembler = candidateDetailsAssembler;
    }

    [HttpGet(Name = "FindAllCandidates")]
    public IActionResult FindAll()
    {
        var candidates = _candidateService.FindAll();
        return Ok(_candidateSummaryAssembler.ToResourceCollection(candidates, HttpContext));
    }

    [HttpPost(Name = "CreateCandidate")]
    public IActionResult Create([FromBody] CandidateRequest request)
    {
        var candidate = _candidateService.Create(request);
        return CreatedAtAction(
            nameof(FindById),
            new { id = candidate.Id },
            _candidateDetailsAssembler.ToResource(candidate, HttpContext));
    }

    [HttpGet("{id}", Name = "FindCandidateById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var candidate = _candidateService.FindById(id);
        return Ok(_candidateDetailsAssembler.ToResource(candidate, HttpContext));
    }

    [HttpPut("{id}", Name = "UpdateCandidateById")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] CandidateRequest request)
    {
        var candidate = _candidateService.UpdateById(id, request);
        return Ok(_candidateDetailsAssembler.ToResource(candidate, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteCandidateById")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _candidateService.DeleteById(id);
        return NoContent();
    }
}