using DonateHope.Domain.Entities;
using DonateHope.Domain.IdentityEntities;

namespace DonateHope.Core.DTOs.CampaignCommentDTOs;

public class CampaignCommentGetResponseDto
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CampaignId { get; set; }
    public AppUser? User { get; set; }

    public Campaign? Campaign { get; set; }
}
