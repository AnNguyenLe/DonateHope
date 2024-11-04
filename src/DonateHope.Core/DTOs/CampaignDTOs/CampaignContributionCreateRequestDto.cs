namespace DonateHope.Core.DTOs.CampaignDTOs;

public class CampaignContributionCreateRequestDto
{
    public decimal Amount { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public string? ContributionMethod { get; set; }
    public Guid? CampaignId { get; set; }
}