using DonateHope.Core.DTOs.CampaignDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignsServiceContracts;

public interface ICampaignRetrieveService
{
    Task<Result<IEnumerable<CampaignGetResponseDto>>> GetCampaigns();
    Task<Result<CampaignGetResponseDto>> GetCampaignByIdAsync(Guid campaignId);
}
