using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;

public interface ICampaignCommentCreatingService
{
    Task<Result<CampaignComment>> CreateCampaignCommentAsync(
        CampaignCommentCreateRequestDto campaignCommentCreateRequestDto,
    string userId
    );
}
