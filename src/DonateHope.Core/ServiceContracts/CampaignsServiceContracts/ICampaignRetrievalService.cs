using DonateHope.Core.DTOs.CampaignDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignsServiceContracts;

public interface ICampaignRetrievalService
{
    Task<Result<CampaignGetResponseDto>> GetCampaignByIdAsync(Guid campaignId);
}
