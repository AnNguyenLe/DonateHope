using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Core.Validators.CampaignContribution;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionDeletingService(
    ILogger<CampaignContributionDeletingService> logger,
    ICampaignContributionsRepository campaignContributionsRepository,
    CampaignContributionMapper campaignContributionMapper
    ) : ICampaignContributionDeletingService
{
    private readonly ILogger<CampaignContributionDeletingService> _logger = logger;
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;

    public async Task<Result<CampaignContributionDeleteResponseDto>> DeleteCampaignContributionAsync(
        Guid campaignContributionId,
        Guid deletedBy,
        string reasonForDeletion 
        )
    {
        var queryResult = await _campaignContributionsRepository.GetCampaignContributionById(campaignContributionId);
        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            _logger.LogWarning(
                "Failed to retrieve campaign contribution {CampaignContributionId}. Error: {ErrorMessage}",
                campaignContributionId,
                queryResult.Errors.First().Message
                );
            return new ProblemDetailsError(queryResult.Errors.First().Message);
        }
        
        var deletedCampaignContribution = queryResult.Value;
        if (deletedCampaignContribution.IsDeleted)
        {
            _logger.LogWarning("The campaign contribution {CampaignContributionId} is already marked as deleted.", deletedCampaignContribution.Id);
            return new ProblemDetailsError("This campaign contribution does not exist.");
        }
        
        deletedCampaignContribution.DeletedAt = DateTime.UtcNow;
        deletedCampaignContribution.DeletedBy = deletedBy;
        deletedCampaignContribution.ReasonForDeletion = reasonForDeletion;
        
        var deletedResult = await _campaignContributionsRepository.DeleteCampaignContribution(
            campaignContributionId,
            deletedBy,
            reasonForDeletion
        );

        if (deletedResult.IsFailed)
        {
            _logger.LogWarning(
                "Failed to delete campaign contribution {CampaignContributionId}. Error: {ErrorMessage}",
                campaignContributionId,
                deletedResult.Errors.First().Message
                );
            return new ProblemDetailsError("Failed to delete campaign contribution.");
        }
        
        _logger.LogInformation(
            "Successfully deleted campaign contribution {CampaignContributionId}", campaignContributionId);
        return _campaignContributionMapper.MapCampaignContributionToCampaignContributionDeleteResponseDto(deletedCampaignContribution);
    }
}