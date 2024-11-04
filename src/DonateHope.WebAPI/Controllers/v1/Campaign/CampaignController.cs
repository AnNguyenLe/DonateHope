using Asp.Versioning;
using DonateHope.Core.Common.ExtensionMethods;
using DonateHope.Core.ConfigurationOptions.AppServer;
using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace DonateHope.WebAPI.Controllers.v1.Campaign;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/campaign")]
[ApiController]
public class CampaignController(
    UserManager<AppUser> userManager,
    CampaignMapper campaignMapper,
    IOptions<MyAppServerConfiguration> myAppServerConfiguration,
    ICampaignCreatingService campaignCreatingService,
    ICampaignRetrievalService campaignRetrievalService,
    ICampaignUpdatingService campaignUpdatingService
) : CustomControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly CampaignMapper _campaignMapper = campaignMapper;
    private readonly MyAppServerConfiguration _app = myAppServerConfiguration.Value;
    private readonly ICampaignCreatingService _campaignCreatingService = campaignCreatingService;
    private readonly ICampaignRetrievalService _campaignRetrievalService = campaignRetrievalService;
    private readonly ICampaignUpdatingService _campaignUpdatingService = campaignUpdatingService;

    [HttpPost("create", Name = nameof(CreateCampaign))]
    public async Task<ActionResult<CampaignGetResponseDto>> CreateCampaign(
        [FromBody] CampaignCreateRequestDto createRequestDto
    )
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return BadRequestProblemDetails("Unable to identify user.");
        }

        if (!Guid.TryParse(userId, out var parsedUserId))
        {
            return BadRequestProblemDetails("Unable to identify user.");
        }

        var result = await _campaignCreatingService.CreateCampaignAsync(
            createRequestDto,
            parsedUserId
        );

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        var campaign = result.Value;

        return CreatedAtRoute(nameof(GetCampaign), new { id = campaign.Id }, campaign);
    }

    [HttpGet("{id}", Name = nameof(GetCampaign))]
    public async Task<ActionResult<CampaignGetResponseDto>> GetCampaign([FromRoute] string id)
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return BadRequestProblemDetails("Unable to identify user.");
        }

        if (!Guid.TryParse(id, out var campaignId))
        {
            return BadRequestProblemDetails("Invalid ID format");
        }

        var result = await _campaignRetrievalService.GetCampaignByIdAsync(campaignId);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        return result.Value;
    }

    [HttpPut("{id}", Name = nameof(UpdateCampaign))]
    public async Task<ActionResult<CampaignGetResponseDto>> UpdateCampaign(
        [FromRoute] string id,
        [FromBody] CampaignUpdateRequestDto updateRequestDto
    )
    {
        if (!Guid.TryParse(id, out var campaignId))
        {
            return BadRequestProblemDetails("Invalid ID format.");
        }

        if (campaignId != updateRequestDto.Id)
        {
            return BadRequestProblemDetails("Campaign ID does not match.");
        }

        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return BadRequestProblemDetails("Unable to identify user.");
        }

        if (!Guid.TryParse(userId, out var parsedUserId))
        {
            return BadRequestProblemDetails("Unable to identify user.");
        }

        var updateResult = await _campaignUpdatingService.UpdateCampaignAsync(
            updateRequestDto,
            parsedUserId
        );

        if (updateResult.IsFailed)
        {
            return updateResult.Errors.ToDetailedBadRequest();
        }

        return NoContent();
    }
}
