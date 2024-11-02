using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace DonateHope.Core.Mappers;

[Mapper]
public partial class CampaignMapper
{
    [MapperIgnoreTarget(nameof(Campaign.Id))]
    [MapperIgnoreTarget(nameof(Campaign.AchievedAmount))]
    [MapperIgnoreTarget(nameof(Campaign.GoalStatus))]
    [MapperIgnoreTarget(nameof(Campaign.StartDate))]
    [MapperIgnoreTarget(nameof(Campaign.EndDate))]
    [MapperIgnoreTarget(nameof(Campaign.NumberOfRatings))]
    [MapperIgnoreTarget(nameof(Campaign.AverageRatingPoint))]
    [MapperIgnoreTarget(nameof(Campaign.SpendingAmount))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignStatus))]
    [MapperIgnoreTarget(nameof(Campaign.CreatedAt))]
    [MapperIgnoreTarget(nameof(Campaign.CreatedBy))]
    [MapperIgnoreTarget(nameof(Campaign.UpdatedAt))]
    [MapperIgnoreTarget(nameof(Campaign.UpdatedBy))]
    [MapperIgnoreTarget(nameof(Campaign.IsDeleted))]
    [MapperIgnoreTarget(nameof(Campaign.DeletedAt))]
    [MapperIgnoreTarget(nameof(Campaign.DeletedBy))]
    [MapperIgnoreTarget(nameof(Campaign.IsActive))]
    [MapperIgnoreTarget(nameof(Campaign.ActiveStatusNote))]
    [MapperIgnoreTarget(nameof(Campaign.UserId))]
    [MapperIgnoreTarget(nameof(Campaign.User))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignRatings))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignComments))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignContributions))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignLogs))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignReports))]
    [MapperIgnoreTarget(nameof(Campaign.CampaignStatusId))]
    public partial Campaign MapCampaignCreateRequestDtoToCampaign(CampaignCreateRequestDto dto);

    [MapperIgnoreSource(nameof(Campaign.Id))]
    [MapperIgnoreSource(nameof(Campaign.IsDeleted))]
    [MapperIgnoreSource(nameof(Campaign.DeletedAt))]
    [MapperIgnoreSource(nameof(Campaign.DeletedBy))]
    [MapperIgnoreSource(nameof(Campaign.IsActive))]
    [MapperIgnoreSource(nameof(Campaign.ActiveStatusNote))]
    [MapperIgnoreSource(nameof(Campaign.UserId))]
    [MapperIgnoreSource(nameof(Campaign.User))]
    [MapperIgnoreSource(nameof(Campaign.CampaignRatings))]
    [MapperIgnoreSource(nameof(Campaign.CampaignComments))]
    [MapperIgnoreSource(nameof(Campaign.CampaignContributions))]
    [MapperIgnoreSource(nameof(Campaign.CampaignLogs))]
    [MapperIgnoreSource(nameof(Campaign.CampaignReports))]
    [MapperIgnoreSource(nameof(Campaign.CampaignStatusId))]
    public partial CampaignGetResponseDto MapCampaignToCampaignGetResponseDto(Campaign campaign);
}
