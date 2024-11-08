using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignCommentsRepository
{
    Task<int> AddCampaignComment(CampaignComment campaignComment);
    Task<Result<CampaignComment>> GetCampaignCommentById(Guid campaignCommentId);
    Task<IEnumerable<CampaignComment>> GetCampaignComments();
    Task<IEnumerable<CampaignComment>> GetCampaignComments(Func<CampaignComment, bool> predicate);
    Task<Result<int>> UpdateCampaignComment(CampaignComment updatedCampaignComment);
    Task<int> DeleteCampaignComment(Guid campaignCommentId);
}
