using System.IdentityModel.Tokens.Jwt;
using Asp.Versioning;
using DonateHope.Core.Common.ExtensionMethods;
using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DonateHope.WebAPI.Controllers.v1.Campaign;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/campaign")]
[ApiController]
public class CampaignController(
    ICampaignCreatingService campaignCreatingService,
    UserManager<AppUser> userManager
) : ControllerBase
{
    private readonly UserManager<AppUser> _userManager = userManager;

    private readonly ICampaignCreatingService _campaignCreatingService = campaignCreatingService;

    [HttpPost]
    [AllowAnonymous]
    [Route("create")]
    public async Task<ActionResult<string>> CreateCampaign(CampaignCreateRequestDto createRequest)
    {
        var userId = _userManager.GetUserId(User);

        if (userId is null)
        {
            return Problem("Unable to identity user.");
        }

        var result = await _campaignCreatingService.CreateCampaignAsync(createRequest, userId);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        return result.Value.ToString();
    }
}
