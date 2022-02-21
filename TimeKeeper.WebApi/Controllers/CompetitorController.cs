using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Business.DTOs;
using TimeKeeper.Business.Services.Abstractions;
using TimeKeeper.Business.Services.Enumerations;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.WebApi.Controllers;

[ApiController]
public class CompetitorController : ControllerBase
{
    private readonly ICompetitorService _competitorService;

    public CompetitorController(ICompetitorService competitorService)
    {
        _competitorService = competitorService;
    }

    [HttpGet]
    [Route("api/test")]
    public string Test() => "Hola Mundo!";

    [HttpGet]
    [Route("api/competitors")]
    public async Task<IActionResult> GetCompetitors(
        CancellationToken cancellationToken)
    {
        var competitors = await _competitorService.GetCompetitors(
            cancellationToken: cancellationToken);

        return Ok(competitors);
    }


    [HttpPost]
    [Route("api/competitors/female")]
    public async Task<IActionResult> AddFemaleCompetitor(
        [FromBody] CompetitorDto competitorDto,
        CancellationToken cancellationToken)
    {
        await _competitorService.AddCompetitor(
            competitorDto: competitorDto,
            category: CompetitorCategory.Female,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(AddFemaleCompetitor), competitorDto);
    }

    [HttpPost]
    [Route("api/competitors/male")]
    public async Task<IActionResult> AddMaleCompetitor(
        [FromBody] CompetitorDto competitorDto,
        CancellationToken cancellationToken)
    {
        await _competitorService.AddCompetitor(
            competitorDto: competitorDto,
            category: CompetitorCategory.Male,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(AddMaleCompetitor), competitorDto);
    }

    [HttpPost]
    [Route("api/teams")]
    public async Task<IActionResult> NewTeam(
        [FromBody] string name,
        CancellationToken cancellationToken)
    {
        await _competitorService.NewTeam(
            name: name,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(NewTeam), name);
    }

    [HttpDelete]
    [Route("api/competitors/{startNo}")]
    public async Task<IActionResult> RemoveCompetitor(
        [FromRoute] ushort startNo,
        CancellationToken cancellationToken)
    {
        await _competitorService.RemoveCompetitor(
            startNo: startNo,
            cancellationToken: cancellationToken);

        return Ok();
    }

}
