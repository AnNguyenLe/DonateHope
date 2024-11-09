using DonateHope.Core.DTOs.CampaignCommentDTOs;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;

public interface ICampaignCommentRetrievalService
{
    Task<Result<CampaignCommentGetResponseDto>> GetCampaignCommentById(string campaignCommentId);
}
