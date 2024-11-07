using Asp.Versioning;
using DonateHope.Core.Common.ExtensionMethods;
using DonateHope.Core.ConfigurationOptions.AppServer;
using DonateHope.Core.DTOs.CampaignContributionDTOs;
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
    ICampaignContributionUpdatingService campaignContributionUpdatingService,
    ICampaignContributionDeletingService campaignContributionDeletingService,
    UserManager<AppUser> userManager,
    IOptions<MyAppServerConfiguration> myAppServerConfiguration,
    CampaignContributionMapper campaignContributionMapper
    ) : CustomControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;
    private readonly MyAppServerConfiguration _app = myAppServerConfiguration.Value;
    private readonly ICampaignContributionCreatingService _campaignContributionCreatingService = campaignContributionCreatingService;
    private readonly ICampaignContributionRetrievalService _campaignContributionRetrievalService = campaignContributionRetrievalService;
    private readonly ICampaignContributionUpdatingService _campaignContributionUpdatingService = campaignContributionUpdatingService;
    private readonly ICampaignContributionDeletingService _campaignContributionDeletingService = campaignContributionDeletingService;

    [HttpPost("create", Name = nameof(CreateCampaignContribution))]
    public async Task<ActionResult<CampaignContributionGetResponseDto>> CreateCampaignContribution(
        [FromBody] CampaignContributionCreateRequestDto createRequest)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return BadRequestProblemDetails("Unable to identify user");
        }

        if (!Guid.TryParse(userId, out var parsedUserId))
        {
            return BadRequestProblemDetails("Unable to identify user");
        }
        
        var result = await _campaignContributionCreatingService.CreateCampaignContributionAsync(
            createRequest,
            parsedUserId
            );

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        var campaignContribution = result.Value;
        
        return CreatedAtRoute(
            nameof(GetCampaignContribution),
            new { id = campaignContribution.Id },
            campaignContribution
            );
    }

    [HttpGet("{id}", Name = nameof(GetCampaignContribution))]
    public async Task<ActionResult<CampaignContributionGetResponseDto>> GetCampaignContribution([FromRoute] Guid id)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return BadRequestProblemDetails("Unable to identify user");
        }
        var result = await _campaignContributionRetrievalService.GetCampaignContributionByIdAsync(id);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }
        return result.Value;
    }

    [HttpPut("{id}", Name = nameof(UpdateCampaignContribution))]
    public async Task<ActionResult<CampaignContributionGetResponseDto>> UpdateCampaignContribution(
        [FromRoute] string id,
        [FromBody] CampaignContributionUpdateRequestDto updateRequestDto
    )
    {
        if (!Guid.TryParse(id, out var campaignContributionId))
        {
            return BadRequestProblemDetails("Invalid ID format");
        }

        if (campaignContributionId != updateRequestDto.Id)
        {
            return BadRequestProblemDetails("Campaign Contribution ID does not match.");
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

        var updatedResult = await _campaignContributionUpdatingService.UpdateCampaignContributionAsync(
            updateRequestDto,
            parsedUserId
        );

        if (updatedResult.IsFailed)
        {
            return updatedResult.Errors.ToDetailedBadRequest();
        }
        
        return CreatedAtRoute(
            nameof(UpdateCampaignContribution),
            new { id = campaignContributionId },
            updatedResult.Value);
    }

    [HttpDelete("{id}", Name = nameof(DeleteCampaignContribution))]
    public async Task<ActionResult<CampaignContributionDeleteResponseDto>> DeleteCampaignContribution(
        [FromRoute] string id,
        [FromBody] CampaignContributionDeleteRequestDto reasonForDeletionRequestDto)
    {
        if (!Guid.TryParse(id, out var campaignContributionId))
        {
            return BadRequestProblemDetails("Invalid ID format");
        }
        var userId = _userManager.GetUserId(User);
        
        if (userId is null)
        {
            return BadRequestProblemDetails("Unable to identify user");
        }

        if (!Guid.TryParse(userId, out var deletedBy))
        {
            return BadRequestProblemDetails("Invalid user identification");
        }
        
        var result = await _campaignContributionDeletingService.DeleteCampaignContributionAsync(
            campaignContributionId,
            deletedBy,
            reasonForDeletionRequestDto.ReasonForDeletion
            );

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }
        return result.Value;
    }
}