using DonateHope.Domain.IdentityEntities;

namespace DonateHope.Domain.Entities;

public class CampaignRating
{
    public Guid Id { get; init; }
    public string? Feedback { get; set; }
    public double RatingPoint { get; set; }
    public Guid UserId { get; init; }
    public Guid CampaignId { get; init; }
    public AppUser? User { get; set; }
    public Campaign? Campaign { get; set; }
}
