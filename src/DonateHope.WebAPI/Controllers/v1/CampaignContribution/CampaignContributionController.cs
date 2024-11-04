using Asp.Versioning;
using DonateHope.Core.Common.ExtensionMethods;
using DonateHope.Core.ConfigurationOptions.AppServer;
using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DonateHope.WebAPI.Controllers.v1.CampaignContribution;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/campaign-contribution")]
[ApiController]
public class CampaignContributionController(
    ICampaignContributionCreatingService campaignContributionCreatingService,
    ICampaignContributionRetrievalService campaignContributionRetrievalService,
    UserManager<AppUser> userManager,
    IOptions<MyAppServerConfiguration> myAppServerConfiguration,
    CampaignContributionMapper campaignContributionMapper
    ) : ControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;
    private readonly MyAppServerConfiguration _app = myAppServerConfiguration.Value;
    private readonly ICampaignContributionCreatingService _campaignContributionCreatingService = campaignContributionCreatingService;
    private readonly ICampaignContributionRetrievalService _campaignContributionRetrievalService = campaignContributionRetrievalService;

    [HttpPost("create", Name = nameof(CreateCampaignContribution))]
    public async Task<ActionResult<string>> CreateCampaignContribution(
        [FromBody] CampaignContributionCreateRequestDto createRequest)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Problem("Unable to identify user");
        }
        var result = await _campaignContributionCreatingService.CreateCampaignContributionAsync(createRequest, userId);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        var campaignContribution = result.Value;
        
        return CreatedAtRoute(
            nameof(GetCampaignContribution),
            new { id = campaignContribution.Id },
            _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(campaignContribution)
            );
    }

    [HttpGet("{id}", Name = nameof(GetCampaignContribution))]
    public async Task<ActionResult<CampaignContributionGetResponseDto>> GetCampaignContribution([FromRoute] string id)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Problem("Unable to identify user");
        }
        var result = await _campaignContributionRetrievalService.GetCampaignContributionByIdAsync(id);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }
        return result.Value;
    }
}