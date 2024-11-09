using Asp.Versioning;
using DonateHope.Core.Common.ExtensionMethods;
using DonateHope.Core.ConfigurationOptions.AppServer;
using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;
using DonateHope.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DonateHope.WebAPI.Controllers.v1.CampaignComment;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/campaign-comment")]
[ApiController]
public class CampaignCommentController(
    ICampaignCommentCreatingService campaignCommentCreatingService,
    ICampaignCommentRetrievalService campaignCommentRetrievalService,
    ICampaignCommentUpdateService campaignCommentUpdateService,
    UserManager<AppUser> userManager,
    IOptions<MyAppServerConfiguration> myAppServerConfiguration,
    CampaignCommentMapper campaignCommentMapper
) : CustomControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly CampaignCommentMapper _campaignCommentMapper = campaignCommentMapper;
    private readonly MyAppServerConfiguration _app = myAppServerConfiguration.Value;
    private readonly ICampaignCommentCreatingService _campaignCommentCreatingService = campaignCommentCreatingService;
    private readonly ICampaignCommentRetrievalService _campaignCommentRetrievalService = campaignCommentRetrievalService;
    private readonly ICampaignCommentUpdateService _campaignCommentUpdateService = campaignCommentUpdateService;

    [HttpPost("create", Name = nameof(CreateCampaignComment))]
    public async Task<ActionResult<string>> CreateCampaignComment(
        [FromBody] CampaignCommentCreateRequestDto createRequest
    )
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return Problem("Unable to identify user.");
        }

        var result = await _campaignCommentCreatingService.CreateCampaignCommentAsync(createRequest, userId);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        var campaignComment = result.Value;

        return CreatedAtRoute(
            nameof(CreateCampaignComment),
            new { id = campaignComment.Id },
            _campaignCommentMapper.MapCampaignCommentToCampaignCommentGetResponseDto(campaignComment)

        );
    }

    [HttpGet("{id}", Name = nameof(GetCampaignComment))]
    public async Task<ActionResult<CampaignCommentGetResponseDto>> GetCampaignComment([FromRoute] string id)
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return Problem("Unable to identify user.");
        }

        var result = await _campaignCommentRetrievalService.GetCampaignCommentById(id);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        return result.Value;
    }
    [HttpPut("{id}", Name = nameof(UpdateCampaignComment))]
    public async Task<ActionResult<CampaignCommentUpdateRequestDto>> UpdateCampaignComment([FromRoute] string id, [FromBody] CampaignCommentUpdateRequestDto updateCampaignCommentDto)
    {
        if (!Guid.TryParse(id, out var campaignCommentId))
        {
            return BadRequestProblemDetails("Invalid ID format.");
        }

        if (campaignCommentId != updateCampaignCommentDto.Id)
        {
            return BadRequestProblemDetails("Campaign Comment ID does not match.");
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

        var updateResult = await _campaignCommentUpdateService.UpdateCampaignCommentAsync(
            updateCampaignCommentDto,
            parsedUserId
        );

        if (updateResult.IsFailed)
        {
            return updateResult.Errors.ToDetailedBadRequest();
        }

        return NoContent();
    }
}
