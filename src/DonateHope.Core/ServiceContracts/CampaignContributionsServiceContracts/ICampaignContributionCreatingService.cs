using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionCreatingService
{
    Task<Result<CampaignContributionGetResponseDto>> CreateCampaignContributionAsync(
        CampaignContributionCreateRequestDto campaignContributionCreateRequestDto,
        Guid userId
        );
}