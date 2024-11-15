using DonateHope.Core.DTOs.CampaignCommentDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;

public interface ICampaignCommentRetrieveService
{
    Task<Result<CampaignCommentGetResponseDto>> GetCampaignCommentById(Guid campaignCommentId);
}
