using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.EntityExtensions;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionCreatingService(
    ILogger<CampaignContributionCreatingService> logger,
    ICampaignContributionsRepository campaignContributionsRepository,
    ICampaignsRepository campaignsRepository,
    CampaignContributionMapper campaignContributionMapper
    ) : ICampaignContributionCreatingService
{
    private readonly ILogger<CampaignContributionCreatingService> _logger = logger;
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;

    public async Task<Result<CampaignContributionGetResponseDto>> CreateCampaignContributionAsync(
        CampaignContributionCreateRequestDto campaignContributionCreateRequestDto,
        Guid userId
    )
    {
        var campaignContribution = _campaignContributionMapper
            .MapCampaignContributionCreateRequestDtoToCampaignContribution(campaignContributionCreateRequestDto)
            .OnCampaignContributionCreating(userId);

        var campaign = await _campaignsRepository.GetCampaignById(campaignContribution.CampaignId);
        if (campaign.ValueOrDefault is null)
        {
            _logger.LogWarning("Campaign not found for Id: {CampaignId}.", campaignContribution.CampaignId);
            return new ProblemDetailsError("Campaign not found.");
        }
        
        var queryResult = await _campaignContributionsRepository.AddCampaignContribution(campaignContribution);
        if (queryResult.IsFailed)
        {
            return new ProblemDetailsError(
                "Unexpected error(s) during the campaign contribution creating process. Please contact support team."
            );
        }
        
        var totalAffectedRows = queryResult.ValueOrDefault;
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Failed to create campaign contribution.");
        }
        
        _logger.LogInformation("Successfully created campaign contribution.");
        
        var mappedDto = _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(campaignContribution);
        return mappedDto;
    }
}