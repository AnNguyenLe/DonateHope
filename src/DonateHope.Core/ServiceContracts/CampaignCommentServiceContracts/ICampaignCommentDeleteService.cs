using DonateHope.Core.DTOs.CampaignCommentDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;

public interface ICampaignCommentDeleteService
{
    Task<Result<CampaignCommentDeleteDto>> DeleteCampaignCommentAsync(Guid campaignCommentId, Guid deletedBy, string reasonForDeletion);
}