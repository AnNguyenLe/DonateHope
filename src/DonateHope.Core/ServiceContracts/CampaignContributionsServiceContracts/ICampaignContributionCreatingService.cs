using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionCreatingService
{
    Task<Result<CampaignContribution>> CreateCampaignContributionAsync(
        CampaignContributionCreateRequestDto campaignContributionCreateRequestDto,
        string userId
        );
}