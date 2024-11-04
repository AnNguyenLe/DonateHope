using DonateHope.Core.DTOs.CampaignDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionRetrievalService
{
    Task<Result<CampaignContributionGetResponseDto>> GetCampaignContributionByIdAsync(string campaignContributionId);
}