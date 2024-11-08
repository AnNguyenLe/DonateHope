using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace DonateHope.Core.Mappers;

[Mapper]
public partial class CampaignCommentMapper
{
    [MapperIgnoreTarget(nameof(CampaignComment.IsDeleted))]
    [MapperIgnoreTarget(nameof(CampaignComment.DeletedAt))]
    [MapperIgnoreTarget(nameof(CampaignComment.DeletedBy))]
    [MapperIgnoreTarget(nameof(CampaignComment.UpdatedBy))]
    [MapperIgnoreTarget(nameof(CampaignComment.IsBanned))]
    [MapperIgnoreTarget(nameof(CampaignComment.BannedStatusNote))]
    public partial CampaignComment MapCampaignCommentCreateRequestDtoToCampaignComment(CampaignCommentCreateRequestDto dto);
    
    [MapperIgnoreSource(nameof(CampaignComment.IsDeleted))]
    [MapperIgnoreSource(nameof(CampaignComment.DeletedAt))]
    [MapperIgnoreSource(nameof(CampaignComment.DeletedBy))]
    [MapperIgnoreSource(nameof(CampaignComment.UpdatedBy))]
    [MapperIgnoreSource(nameof(CampaignComment.IsBanned))]
    [MapperIgnoreSource(nameof(CampaignComment.BannedStatusNote))]
    public partial CampaignCommentGetResponseDto MapCampaignCommentToCampaignCommentGetResponseDto(CampaignComment campaignComment);
}