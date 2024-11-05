namespace DonateHope.Core.DTOs.CampaignContributionDTOs;

public class CampaignContributionUpdateRequestDto : CampaignContributionCreateRequestDto
{
    public Guid campaignId;
    public Guid Id { get; init; }
}