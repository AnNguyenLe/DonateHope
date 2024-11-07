using DonateHope.Core.DTOs.CampaignContributionDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionCreatingService
{
    Task<Result<CampaignContributionGetResponseDto>> CreateCampaignContributionAsync(
        CampaignContributionCreateRequestDto campaignContributionCreateRequestDto,
        Guid userId
        );
}