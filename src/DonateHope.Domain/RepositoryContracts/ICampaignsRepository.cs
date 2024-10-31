using DonateHope.Domain.Entities;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignsRepository
{
    Task<int> AddCampaign(Campaign campaign);
    Task<IEnumerable<Campaign>> GetCampaigns();
    Task<IEnumerable<Campaign>> GetCampaigns(Func<Campaign, bool> predicate);
    Task<int> DeleteCampaign(Guid campaignId);
    Task<int> DeleteCampaignPermanently(Guid campaignId);
}
