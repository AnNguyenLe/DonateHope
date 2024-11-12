namespace DonateHope.Core.DTOs.CampaignReportDTOs;

public class CampaignReportDeleteResponseDto
{
    public Guid Id { get; set; }
    public DateTime? FromDateTime { get; set; }
    public DateTime? ToDateTime { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public string? Summary { get; set; }
    public string? Detail { get; set; }
    public decimal Amount { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public string? DocumentsUrl { get; set; }
    public Guid? CampaignId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public string? ReasonForDeletion { get; set; }
}