using DonateHope.Core.DTOs.CampaignRatingDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignRatingsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignRatingServices;

public class CampaignRatingUpdatingService (
    CampaignRatingMapper campaignRatingMapper,
    ICampaignRatingsRepository campaignRatingsRepository
    ) : ICampaignRatingUpdatingService
{
    private readonly CampaignRatingMapper _campaignRatingMapper = campaignRatingMapper;
    private readonly ICampaignRatingsRepository _campaignRatingsRepository = campaignRatingsRepository;

    public async Task<Result<CampaignRatingGetResponseDto>> UpdateCampaignRatingAsync(
        CampaignRatingUpdateRequestDto updateRequestDto,
        Guid userId
    )
    {
        var queryResult = await _campaignRatingsRepository.GetCampaignRatingById(updateRequestDto.Id);

        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            return new ProblemDetailsError("Campaign rating not found.");
        }

        var currentCampaignRating = queryResult.Value;
        
        if (userId != currentCampaignRating.UserId)
        {
            return new ProblemDetailsError("You are unauthorized to update this campaign rating.");
        }
        
        var updatedCampaignRating = _campaignRatingMapper.MapCampaignRatingUpdateRequestDtoToCampaignRating(updateRequestDto);
        updatedCampaignRating.CreatedAt = currentCampaignRating.CreatedAt;
        updatedCampaignRating.CreatedBy = currentCampaignRating.CreatedBy;
        updatedCampaignRating.CampaignId = currentCampaignRating.CampaignId;
        
        updatedCampaignRating.UpdatedAt = DateTime.UtcNow;
        updatedCampaignRating.UpdatedBy = userId;
        
        var updateResult = await _campaignRatingsRepository.UpdateCampaignRating(updatedCampaignRating);
        if (updateResult.IsFailed)
        {
            return new ProblemDetailsError("Failed to update campaign rating.");
        }

        return _campaignRatingMapper.MapCampaignRatingToCampaignRatingGetResponseDto(updatedCampaignRating);
    }
}