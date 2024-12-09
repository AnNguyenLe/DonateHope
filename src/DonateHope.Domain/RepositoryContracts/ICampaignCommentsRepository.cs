using System.Linq.Expressions;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignCommentsRepository
{
    Task<int> AddCampaignComment(CampaignComment campaignComment);
    Task<Result<CampaignComment>> GetCampaignCommentById(Guid campaignCommentId);
    Task<IEnumerable<CampaignComment>> GetCommentsByCampaignId(Guid campaignId);
    Task<Result<int>> UpdateCampaignComment(CampaignComment updatedCampaignComment);
    Task<Result<int>> DeleteCampaignComment(Guid campaignCommentId, Guid deletedBy);
    Task<Result<int>> DeleteCampaignCommentPermanently(Guid campaignCommentId);

}
