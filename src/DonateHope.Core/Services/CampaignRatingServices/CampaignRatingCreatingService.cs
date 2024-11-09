using DonateHope.Core.DTOs.CampaignRatingDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignRatingsServiceContracts;
using DonateHope.Core.Services.CampaignContributionServices;
using DonateHope.Domain.EntityExtensions;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace DonateHope.Core.Services.CampaignRatingServices;

public class CampaignRatingCreatingService(
    ILogger<CampaignContributionCreatingService> logger,
    ICampaignRatingsRepository campaignRatingsRepository,
    ICampaignsRepository campaignsRepository,
    CampaignRatingMapper campaignRatingMapper
    ) : ICampaignRatingCreatingService
{
    private readonly ILogger<CampaignContributionCreatingService> _logger = logger;
    private readonly ICampaignRatingsRepository _campaignRatingsRepository = campaignRatingsRepository;
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;
    private readonly CampaignRatingMapper _campaignRatingMapper = campaignRatingMapper;

    public async Task<Result<CampaignRatingGetResponseDto>> CreateCampaignRatingAsync(
        CampaignRatingCreateRequestDto campaignRatingCreateRequestDto,
        Guid userId
    )
    {
        var campaignRating = _campaignRatingMapper
            .MapCampaignRatingCreateRequestDtoToCampaignRating(campaignRatingCreateRequestDto)
            .OnCampaignRatingCreating(userId);
        
        var campaign = await _campaignsRepository.GetCampaignById(campaignRating.CampaignId);
        if (campaign.ValueOrDefault is null)
        {
            _logger.LogWarning("Campaign not found for Id: {CampaignId}.", campaignRating.CampaignId);
            return new ProblemDetailsError("Campaign not found.");
        }
        
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