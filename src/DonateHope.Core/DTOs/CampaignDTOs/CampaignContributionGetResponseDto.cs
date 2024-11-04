using DonateHope.Domain.Entities;

namespace DonateHope.Core.DTOs.CampaignDTOs;

public class CampaignContributionGetResponseDto
{
    public decimal Amount { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public string? ContributionMethod { get; set; }
    public Guid? CampaignId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}