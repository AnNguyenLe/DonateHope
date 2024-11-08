using DonateHope.Domain.Entities;
using DonateHope.Domain.IdentityEntities;

namespace DonateHope.Core.DTOs.CampaignCommentDTOs;

public class CampaignCommentUpdateRequestDto
{
    public Guid Id { get; init; }
    public string? Content { get; set; }
    // public Guid? UserId { get; set; }
    // public Guid? CampaignId { get; set; }

}
