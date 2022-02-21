using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Business.DTOs;
using TimeKeeper.Business.Services.Abstractions;

namespace TimeKeeper.WebApi.Controllers;

[ApiController]
public class RaceController : ControllerBase
{
    private readonly IRaceService _raceService;

    public RaceController(IRaceService raceService)
    {
        _raceService = raceService;
    }

    [HttpGet]
    [Route("api/races/{name}")]
    public async Task<IActionResult> GetRaceByName(
        [FromRoute] string name,
        CancellationToken cancellationToken)
    {
        var race = await _raceService.GetRaceByName(
            name: name,
            cancellationToken: cancellationToken);

        return Ok(race);
    }

    [HttpGet]
    [Route("api/stages/{raceName}")]
    public async Task<IActionResult> GetStagesOnRace(
        [FromRoute] string raceName,
        CancellationToken cancellationToken)
    {
        var stages = await _raceService.GetStagesOnRace(
            raceName: raceName,
            cancellationToken: cancellationToken);

        return Ok(stages);
    }

    [HttpPost]
    [Route("api/races")]
    public async Task<IActionResult> NewRace(
        [FromQuery] string name,
        CancellationToken cancellationToken)
    {
        await _raceService.NewRace(
            name: name,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(NewRace), name);
    }

    [HttpPost]
    [Route("api/stages")]
    public async Task<IActionResult> AddStage(
        [FromBody] StageDto stageDto,
        CancellationToken cancellationToken)
    {
        await _raceService.AddStage(
            stageDto: stageDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(AddStage), stageDto);
    }
}
