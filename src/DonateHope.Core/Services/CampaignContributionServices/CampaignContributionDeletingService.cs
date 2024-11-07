using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionDeletingService(
    ICampaignContributionsRepository campaignContributionsRepository,
    CampaignContributionMapper campaignContributionMapper
    ) : ICampaignContributionDeletingService
{
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;

    public async Task<Result<CampaignContributionDeleteResponseDto>> DeleteCampaignContributionAsync(
        Guid campaignContributionId,
        Guid deletedBy,
        String reasonForDeletion 
        )
    {
        // Check if reason for deletion is provided
        if (string.IsNullOrWhiteSpace(reasonForDeletion))
        {
            return new ProblemDetailsError("Reason for deletion is required.");
        }
        
        var queryResult =
            await _campaignContributionsRepository.GetCampaignContributionById(campaignContributionId);
        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            return new ProblemDetailsError(queryResult.Errors.First().Message);
        }

        // Check if campaign contribution record exists
        var deletedCampaignContribution = queryResult.Value;
        if (deletedCampaignContribution.IsDeleted)
        {
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
            return new ProblemDetailsError("Failed to delete campaign contribution.");
        }
        
        return _campaignContributionMapper.MapCampaignContributionToCampaignContributionDeleteResponseDto(deletedCampaignContribution);
    }
}