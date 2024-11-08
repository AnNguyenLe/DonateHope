using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
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

    public async Task<Result<CampaignContributionGetResponseDto>> GetCampaignContributionByIdAsync(Guid campaignContributionId)
    {
      
        var campaignContributionResult = await _campaignContributionsRepository.GetCampaignContributionById(campaignContributionId);
        if (campaignContributionResult.IsFailed)
        {
            return new ProblemDetailsError(campaignContributionResult.Errors.First().Message);
        }
        
        var mappedDto = _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(campaignContributionResult.Value);

        return mappedDto;
    }
}