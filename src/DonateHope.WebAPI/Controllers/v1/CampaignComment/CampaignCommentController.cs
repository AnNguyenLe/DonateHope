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
[Route("api/v{version:apiVersion}/campaign/{campaignId}/comment")]
[ApiController]
public class CampaignCommentController(
    ICampaignCommentCreatingService campaignCommentCreatingService,
    ICampaignCommentRetrievalService campaignCommentRetrievalService,
    UserManager<AppUser> userManager,
    IOptions<MyAppServerConfiguration> myAppServerConfiguration,
    CampaignCommentMapper campaignCommentMapper
) : ControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly CampaignCommentMapper _campaignCommentMapper = campaignCommentMapper;
    private readonly MyAppServerConfiguration _app = myAppServerConfiguration.Value;
    private readonly ICampaignCommentCreatingService _campaignCommentCreatingService = campaignCommentCreatingService;
    private readonly ICampaignCommentRetrievalService _campaignCommentRetrievalService = campaignCommentRetrievalService;

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
}
