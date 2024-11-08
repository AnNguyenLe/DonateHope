using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;

public interface ICampaignCommentUpdateService
{
    Task<Result> UpdateCampaignCommentAsync(
        CampaignCommentUpdateRequestDto campaignCommentUpdateRequestDto,
    Guid userId);
}
