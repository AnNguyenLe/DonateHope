using DonateHope.Domain.Entities;
using DonateHope.Domain.IdentityEntities;

namespace DonateHope.Core.DTOs.CampaignCommentDTOs;

public class CampaignCommentDeleteDto
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CampaignId { get; set; }
    public string? ReasonForDeletion { get; set; }

}
