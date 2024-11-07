using DonateHope.Core.DTOs.CampaignContributionDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;

public interface ICampaignContributionDeletingService
{
    Task<Result<CampaignContributionDeleteResponseDto>> DeleteCampaignContributionAsync(Guid campaignContributionId, Guid deletedBy, string reasonForDeletion);
}