using System.Linq.Expressions;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignCommentsRepository
{
    Task<int> AddCampaignComment(CampaignComment campaignComment);
    Task<Result<CampaignComment>> GetCampaignCommentById(Guid campaignCommentId);
    IQueryable<CampaignComment> GetCampaignComments(Expression<Func<CampaignComment, bool>> predicate);
    Task<Result<int>> UpdateCampaignComment(CampaignComment updatedCampaignComment);
    Task<Result<int>> DeleteCampaignComment(Guid campaignCommentId, Guid deleteBy, string reasonForDeletion);
    Task<Result<int>> DeleteCampaignCommentPermanently(Guid campaignCommentId);

}
