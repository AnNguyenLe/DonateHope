using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignCommentsRepository
{
    Task<int> AddCampaignComment(CampaignComment campaignComment);
    Task<Result<CampaignComment>> GetCampaignCommentById(Guid campaignCommentId);
    Task<IEnumerable<CampaignComment>> GetCampaignComments();
    Task<IEnumerable<CampaignComment>> GetCampaignComments(Func<CampaignComment, bool> predicate);
    Task<int> ModifyCampaignComment(Guid campaignCommentId, CampaignComment updatedCampaignComment);
    Task<int> DeleteCampaignComment(Guid campaignCommentId);
    Task<int> DeleteCampaignCommentPermanently(Guid campaignCommentId);
}
