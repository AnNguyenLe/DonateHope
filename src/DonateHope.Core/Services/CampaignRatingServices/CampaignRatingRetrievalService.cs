using DonateHope.Core.DTOs.CampaignRatingDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignRatingsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignRatingServices;

public class CampaignRatingRetrievalService(
    ICampaignRatingsRepository campaignRatingsRepository,
    CampaignRatingMapper campaignRatingMapper
    ) : ICampaignRatingRetrievalService
{
    private readonly ICampaignRatingsRepository _campaignRatingsRepository = campaignRatingsRepository;
    private readonly CampaignRatingMapper _campaignRatingMapper = campaignRatingMapper;

    public async Task<Result<CampaignRatingGetResponseDto>> GetCampaignRatingByIdAsync(Guid campaignRatingId)
    {
      
        var campaignRatingResult = await _campaignRatingsRepository.GetCampaignRatingById(campaignRatingId);
        if (campaignRatingResult.IsFailed)
        {
            return new ProblemDetailsError(campaignRatingResult.Errors.First().Message);
        }
        
        var mappedDto = _campaignRatingMapper.MapCampaignRatingToCampaignRatingGetResponseDto(campaignRatingResult.Value);

        return mappedDto;
    }
}