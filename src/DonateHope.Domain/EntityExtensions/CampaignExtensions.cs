using DonateHope.Domain.Entities;

namespace DonateHope.Domain.EntityExtensions;

public static class CampaignExtensions
{
    public static Campaign OnNewCampaignCreating(this Campaign campaign, Guid ownerId)
    {
        var now = DateTime.UtcNow;
        campaign.Id = Guid.NewGuid();
        campaign.CreatedAt = now;
        campaign.CreatedBy = ownerId;
        campaign.UpdatedAt = now;
        campaign.CreatedBy = ownerId;
        campaign.IsActive = false;
        campaign.AchievedAmount = 0;
        campaign.NumberOfRatings = 0;
        campaign.AverageRatingPoint = 0;
        campaign.SpendingAmount = 0;
        campaign.ProofsUrl = string.Empty;
        campaign.UserId = ownerId;
        campaign.AchievedAmount = 10;
        campaign.SpendingAmount = 0;

        return campaign;
    }
}