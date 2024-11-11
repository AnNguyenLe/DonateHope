using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionRetrievalService(
    ILogger<CampaignContributionRetrievalService> logger,
    ICampaignContributionsRepository campaignContributionsRepository,
    CampaignContributionMapper campaignContributionMapper
    ) : ICampaignContributionRetrieveService
{
    private readonly ILogger<CampaignContributionRetrievalService> _logger = logger;
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;

    public async Task<Result<CampaignContributionGetResponseDto>> GetCampaignContributionByIdAsync(Guid campaignContributionId)
    { 
        var campaignContributionResult = await _campaignContributionsRepository.GetCampaignContributionById(campaignContributionId);
        if (campaignContributionResult.IsFailed)
        {
            _logger.LogWarning(
                "Failed to retrieve campaign contribution {CampaignContributionId}. Error: {ErrorMessage}", 
                campaignContributionId,
                campaignContributionResult.Errors.First().Message
                );
            return new ProblemDetailsError(campaignContributionResult.Errors.First().Message);
        }
        
        _logger.LogInformation("Successfully retrieved campaign contribution {CampaignContributionId}", campaignContributionId);
        return _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(campaignContributionResult.Value);;
    }
}