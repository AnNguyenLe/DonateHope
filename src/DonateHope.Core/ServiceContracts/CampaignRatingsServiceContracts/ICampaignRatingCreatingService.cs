using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.DTOs.CampaignRatingDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignRatingsServiceContracts;

public interface ICampaignRatingCreatingService
{
    Task<Result<CampaignRatingGetResponseDto>> CreateCampaignRatingAsync(
        CampaignRatingCreateRequestDto campaignRatingCreateRequestDto,
        Guid userId
        );
}