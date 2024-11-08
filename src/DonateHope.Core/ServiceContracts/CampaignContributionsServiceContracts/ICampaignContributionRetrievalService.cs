using DonateHope.Core.DTOs.CampaignContributionDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionRetrievalService
{
    Task<Result<CampaignContributionGetResponseDto>> GetCampaignContributionByIdAsync(Guid campaignContributionId);
}