using Microsoft.AspNetCore.Mvc;
using WorldLeague.API.Dtos;
using WorldLeague.API.Services;

namespace WorldLeague.API.Controllers;

[ApiController]
[Route("api/draw")]
public class DrawController(DrawGroupingService groupingService) : ControllerBase
{
    [HttpPost(Name = "CreateLeagueDraw")]
    public async Task<ActionResult<CreateDrawResponse>> CreateDraw([FromBody] CreateDrawRequest request)
    {
        if (request.GroupCount != 4 && request.GroupCount != 8)
            return BadRequest($"Group count must be 4 or 8.");

        if (string.IsNullOrWhiteSpace(request.DrawerFirstName))
            return BadRequest($"Drawer first name is required");

        if (string.IsNullOrWhiteSpace(request.DrawerLastName))
            return BadRequest($"Drawer last name is required");

        var response = await groupingService.CreateTeamGroups(request);

        return Ok(response);
    }
}