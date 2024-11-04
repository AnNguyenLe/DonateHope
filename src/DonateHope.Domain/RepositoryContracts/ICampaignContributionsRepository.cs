using DonateHope.Domain.Entities;
using FluentResults;

namespace DonateHope.Domain.RepositoryContracts;

public interface ICampaignContributionsRepository
{
    Task<int> AddCampaignContribution(CampaignContribution campaignContribution);
    Task<Result<CampaignContribution>> GetCampaignContributionById(Guid campaignContributionId);
    Task<IEnumerable<CampaignContribution>> GetCampaignContributions();
    Task<IEnumerable<CampaignContribution>> GetCampaignContributions(Func<CampaignContribution, bool> predicate);
    Task<int> ModifyCampaignContribution(Guid campaignContributionId, CampaignContribution updateCampaignContribution);
    Task<int> DeleteCampaignContribution(Guid campaignContributionId);
    Task<int> DeleteCampaignContributionPermanently(Guid campaignContributionId);
}