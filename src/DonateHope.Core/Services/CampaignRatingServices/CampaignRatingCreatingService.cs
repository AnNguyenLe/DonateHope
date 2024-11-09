using DonateHope.Core.DTOs.CampaignRatingDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignRatingsServiceContracts;
using DonateHope.Domain.EntityExtensions;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignRatingServices;

public class CampaignRatingCreatingService(
    ICampaignRatingsRepository campaignRatingsRepository,
    CampaignRatingMapper campaignRatingMapper
    ) : ICampaignRatingCreatingService
{
    private readonly ICampaignRatingsRepository
        _campaignRatingsRepository = campaignRatingsRepository;
    private readonly CampaignRatingMapper _campaignRatingMapper = campaignRatingMapper;

    public async Task<Result<CampaignRatingGetResponseDto>> CreateCampaignRatingAsync(
        CampaignRatingCreateRequestDto campaignRatingCreateRequestDto,
        Guid userId
    )
    {
        var campaignRating = _campaignRatingMapper
            .MapCampaignRatingCreateRequestDtoToCampaignRating(campaignRatingCreateRequestDto)
            .OnCampaignRatingCreating(userId);
        
        var queryResult = await _campaignRatingsRepository.AddCampaignRating(campaignRating);
        if (queryResult.IsFailed)
        {
            return new ProblemDetailsError(
                "Unexpected error(s) during the campaign rating creating process. Please contact support team."
            );
        }
        
        var totalAffectedRows = queryResult.ValueOrDefault;
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Failed to create campaign rating.");
        }
        
        var mappedDto = _campaignRatingMapper.MapCampaignRatingToCampaignRatingGetResponseDto(campaignRating);
        
        return mappedDto;
    }
}