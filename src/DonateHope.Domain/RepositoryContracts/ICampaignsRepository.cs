using System.Linq.Expressions;
using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignsRepository
{
    Task<Result<int>> AddCampaign(Campaign campaign);
    Task<Result<Campaign>> GetCampaignById(Guid campaignId);
    IQueryable<Campaign> GetCampaigns(Expression<Func<Campaign, bool>> predicate);
    Task<Result<int>> UpdateCampaign(Campaign updatedCampaign);
    Task<Result<int>> DeleteCampaign(Guid campaignId, Guid deletedBy, string reasonForDeletion);
    Task<Result<int>> DeleteCampaignPermanently(Guid campaignId);
}
