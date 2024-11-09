using DonateHope.Core.DTOs.CampaignRatingDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignRatingsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignRatingServices;

public class CampaignRatingDeletingService(
    ICampaignRatingsRepository campaignRatingsRepository,
    CampaignRatingMapper campaignRatingMapper
    ) : ICampaignRatingDeletingService
{
    private readonly ICampaignRatingsRepository _campaignRatingsRepository = campaignRatingsRepository;
    private readonly CampaignRatingMapper _campaignRatingMapper = campaignRatingMapper;

    public async Task<Result<CampaignRatingDeleteResponseDto>> DeleteCampaignRatingAsync(
        Guid campaignRatingId,
        Guid deletedBy
        )
    {
        var queryResult =
            await _campaignRatingsRepository.GetCampaignRatingById(campaignRatingId);
        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            return new ProblemDetailsError(queryResult.Errors.First().Message);
        }
        
        var deletedCampaignRating = queryResult.Value;
        if (deletedCampaignRating.IsDeleted)
        {
            return new ProblemDetailsError("This campaign rating does not exist.");
        }
        
        deletedCampaignRating.DeletedAt = DateTime.UtcNow;
        deletedCampaignRating.DeletedBy = deletedBy;
        
        var deletedResult = await _campaignRatingsRepository.DeleteCampaignRating(
            campaignRatingId,
            deletedBy
        );

        if (deletedResult.IsFailed)
        {
            return new ProblemDetailsError("Failed to delete campaign rating.");
        }
        
        return _campaignRatingMapper.MapCampaignRatingToCampaignRatingDeleteResponseDto(deletedCampaignRating);
    }
}