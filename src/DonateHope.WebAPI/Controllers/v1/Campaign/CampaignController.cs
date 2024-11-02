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

namespace DonateHope.WebAPI.Controllers.v1.Campaign;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/campaign")]
[ApiController]
public class CampaignController(
    ICampaignCreatingService campaignCreatingService,
    ICampaignRetrievalService campaignRetrievalService,
    UserManager<AppUser> userManager,
    IOptions<MyAppServerConfiguration> myAppServerConfiguration,
    CampaignMapper campaignMapper
) : ControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly CampaignMapper _campaignMapper = campaignMapper;
    private readonly MyAppServerConfiguration _app = myAppServerConfiguration.Value;
    private readonly ICampaignCreatingService _campaignCreatingService = campaignCreatingService;
    private readonly ICampaignRetrievalService _campaignRetrievalService = campaignRetrievalService;

    [HttpPost("create", Name = "CreateCampaign")]
    public async Task<ActionResult<string>> CreateCampaign(
        [FromBody] CampaignCreateRequestDto createRequest
    )
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return Problem("Unable to identify user.");
        }

        var result = await _campaignCreatingService.CreateCampaignAsync(createRequest, userId);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        var campaign = result.Value;

        return CreatedAtRoute(
            nameof(GetCampaign),
            new { id = campaign.Id },
            _campaignMapper.MapCampaignToCampaignGetResponseDto(campaign)
        );
    }

    [HttpGet("{id}", Name = nameof(GetCampaign))]
    public async Task<ActionResult<CampaignGetResponseDto>> GetCampaign([FromRoute] string id)
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return Problem("Unable to identify user.");
        }

        var result = await _campaignRetrievalService.GetCampaignById(id);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        return result.Value;
    }
}
