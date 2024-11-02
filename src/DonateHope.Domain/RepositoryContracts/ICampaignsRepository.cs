using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignsRepository
{
    Task<int> AddCampaign(Campaign campaign);
    Task<Result<Campaign>> GetCampaignById(Guid campaignId);
    Task<IEnumerable<Campaign>> GetCampaigns();
    Task<IEnumerable<Campaign>> GetCampaigns(Func<Campaign, bool> predicate);
    Task<int> ModifyCampaign(Guid campaignId, Campaign updatedCampaign);
    Task<int> DeleteCampaign(Guid campaignId);
    Task<int> DeleteCampaignPermanently(Guid campaignId);
}
