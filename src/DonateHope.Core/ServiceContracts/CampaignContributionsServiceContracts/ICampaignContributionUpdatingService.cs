using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionUpdatingService
{
    Task<Result<CampaignContributionGetResponseDto>> UpdateCampaignContributionAsync(CampaignContributionUpdateRequestDto updateRequestDto, Guid userId);
}