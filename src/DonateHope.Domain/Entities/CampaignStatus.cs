namespace DonateHope.Domain.Entities;

public class CampaignStatus
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Campaign? Campaign { get; set; }
}
