using DonateHope.Core.DTOs.CampaignDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignsServiceContracts;

public interface ICampaignCreatingService
{
    Task<Result<Guid>> CreateCampaignAsync(
        CampaignCreateRequestDto campaignCreateRequestDto,
        string userId
    );
}
