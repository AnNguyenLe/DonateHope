using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionRetrievalService(
    ICampaignContributionsRepository campaignContributionsRepository,
    CampaignContributionMapper campaignContributionMapper
    ) : ICampaignContributionRetrievalService
{
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;

    public async Task<Result<CampaignContributionGetResponseDto>> GetCampaignContributionByIdAsync(string campaignContributionId)
    {
        if (!Guid.TryParse(campaignContributionId, out var parsedCampaignContributionId))
        {
            return new ProblemDetailsError("Invalid ID format");
        }
        
        var campaignContributionResult = await _campaignContributionsRepository.GetCampaignContributionById(parsedCampaignContributionId);
        if (campaignContributionResult.IsFailed)
        {
            return new ProblemDetailsError(campaignContributionResult.Errors.First().Message);
        }
        
        var mappedDto = _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(campaignContributionResult.Value);

        return mappedDto;
    }
}