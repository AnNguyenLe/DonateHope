using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignsServiceContracts;

public interface ICampaignCreatingService
{
    Task<Result<Campaign>> CreateCampaignAsync(
        CampaignCreateRequestDto campaignCreateRequestDto,
        string userId
    );
}
