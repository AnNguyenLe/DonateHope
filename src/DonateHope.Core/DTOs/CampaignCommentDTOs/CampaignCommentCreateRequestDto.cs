using DonateHope.Domain.Entities;
using DonateHope.Domain.IdentityEntities;
namespace DonateHope.Core.DTOs.CampaignCommentDTOs;

public class CampaignCommentCreateRequestDto
{
    public string? Content { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CampaignId { get; set; }
    public AppUser? User { get; set; }
    public Campaign? Campaign { get; set; }
}
