using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.Enums;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionUpdatingService (
    CampaignContributionMapper campaignContributionContributionMapper,
    ICampaignContributionsRepository campaignContributionsRepository
    ) : ICampaignContributionUpdatingService
{
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionContributionMapper;
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;

    public async Task<Result<CampaignContributionGetResponseDto>> UpdateCampaignContributionAsync(
        CampaignContributionUpdateRequestDto updateRequestDto,
        Guid userId
    )
    {
        // Check if amount is greater than or equal to 0
        if (updateRequestDto.Amount < 0)
        {
            return new ProblemDetailsError("Amount must be greater than or equal to 0.");
        }
        
        // Check if Unit of Measurement is valid
        if (!Enum.TryParse<MeasurementUnits>(updateRequestDto.UnitOfMeasurement, true, out var unitOfMeasurement) || 
            !Enum.IsDefined(typeof(MeasurementUnits), unitOfMeasurement))
        {
            return new ProblemDetailsError("Unit of measurement is not valid.");
        }
        
        // Check if Contribution Method is valid
        if (!Enum.TryParse<ContributionMethods>(updateRequestDto.ContributionMethod, true, out var contributionMethod) ||
            !Enum.IsDefined(typeof(ContributionMethods), contributionMethod))
        {
            return new ProblemDetailsError("Contribution method is not valid.");
        }
        
        // Get query result
        var queryResult = await _campaignContributionsRepository.GetCampaignContributionById(updateRequestDto.Id);

        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            return new ProblemDetailsError("Campaign contribution not found.");
        }

        var currentCampaignContribution = queryResult.Value;
        
        if (userId != currentCampaignContribution.UserId)
        {
            return new ProblemDetailsError("You are unauthorized to update this campaign contribution.");
        }
        
        var updatedCampaignContribution = _campaignContributionMapper.MapCampaignContributionUpdateRequestDtoToCampaignContribution(updateRequestDto);
        updatedCampaignContribution.CreatedAt = currentCampaignContribution.CreatedAt;
        updatedCampaignContribution.CreatedBy = currentCampaignContribution.CreatedBy;
        updatedCampaignContribution.CampaignId = currentCampaignContribution.CampaignId;
        
        updatedCampaignContribution.UpdatedAt = DateTime.UtcNow;
        updatedCampaignContribution.UpdatedBy = userId;
        
        var updateResult = await _campaignContributionsRepository.UpdateCampaignContribution(updatedCampaignContribution);
        if (updateResult.IsFailed)
        {
            return new ProblemDetailsError("Failed to update campaign contribution.");
        }

        return _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(updatedCampaignContribution);
    }
}