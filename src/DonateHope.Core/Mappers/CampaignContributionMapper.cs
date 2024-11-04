using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace DonateHope.Core.Mappers;

[Mapper]
public partial class CampaignContributionMapper
{
    [MapperIgnoreTarget(nameof(CampaignContribution.Id))]
    [MapperIgnoreTarget(nameof(CampaignContribution.UserId))]
    [MapperIgnoreTarget(nameof(CampaignContribution.User))]
    [MapperIgnoreTarget(nameof(CampaignContribution.CreatedAt))]
    [MapperIgnoreTarget(nameof(CampaignContribution.CreatedBy))]
    [MapperIgnoreTarget(nameof(CampaignContribution.UpdatedAt))]
    [MapperIgnoreTarget(nameof(CampaignContribution.UpdatedBy))]
    [MapperIgnoreTarget(nameof(CampaignContribution.IsDeleted))]
    [MapperIgnoreTarget(nameof(CampaignContribution.DeletedAt))]
    [MapperIgnoreTarget(nameof(CampaignContribution.DeletedBy))]
    public partial CampaignContribution MapCampaignContributionCreateRequestDtoToCampaignContribution(CampaignContributionCreateRequestDto campaignContributionCreateRequestDto);
    
    [MapperIgnoreSource(nameof(CampaignContribution.Id))]
    [MapperIgnoreSource(nameof(CampaignContribution.IsDeleted))]
    [MapperIgnoreSource(nameof(CampaignContribution.DeletedAt))]
    [MapperIgnoreSource(nameof(CampaignContribution.DeletedBy))]
    public partial CampaignContributionGetResponseDto MapCampaignContributionToCampaignContributionGetResponseDto(CampaignContribution campaignContribution);
}