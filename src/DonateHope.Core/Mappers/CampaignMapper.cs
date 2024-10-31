using DonateHope.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace DonateHope.Core.DTOs.CampaignDTOs;

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
    public partial Campaign MapCampaignCreateRequestDtoToCampaign(CampaignCreateRequestDto dto);
}
