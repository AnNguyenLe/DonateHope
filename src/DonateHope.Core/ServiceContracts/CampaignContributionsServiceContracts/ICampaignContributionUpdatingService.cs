using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionUpdatingService
{
    Task<Result> UpdateCampaignContributionAsync(CampaignContributionUpdateRequestDto updateRequestDto, Guid userId, Guid campaignId);
}