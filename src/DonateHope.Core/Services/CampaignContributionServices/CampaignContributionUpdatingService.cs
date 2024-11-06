using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.Entities;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionUpdatingService (
    CampaignContributionMapper campaignContributionContributionMapper,
    ICampaignContributionsRepository campaignContributionsRepository
    ) : ICampaignContributionUpdatingService
{
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionContributionMapper;
    private readonly ICampaignContributionsRepository _campaignContributionsRepository = campaignContributionsRepository;

    public async Task<Result<CampaignContributionGetResponseDto>> UpdateCampaignContributionAsync(
        CampaignContributionUpdateRequestDto updateRequestDto,
        Guid userId
    )
    {
        var queryResult = await _campaignContributionsRepository.GetCampaignContributionById(updateRequestDto.Id);

        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            return new ProblemDetailsError("Campaign contribution not found.");
        }

        var currentCampaignContribution = queryResult.Value;
        
        if (userId != currentCampaignContribution.UserId)
        {
            return new ProblemDetailsError("You are unauthorized to update this campaign contribution.");
        }
        
        var updatedCampaignContribution = _campaignContributionMapper.MapCampaignContributionUpdateRequestDtoToCampaignContribution(updateRequestDto);
        updatedCampaignContribution.UpdatedAt = DateTime.UtcNow;
        updatedCampaignContribution.UpdatedBy = userId;
        
        var updateResult = await _campaignContributionsRepository.UpdateCampaignContribution(updatedCampaignContribution);
        if (updateResult.IsFailed)
        {
            return new ProblemDetailsError("Failed to update campaign contribution.");
        }

        return _campaignContributionMapper.MapCampaignContributionToCampaignContributionGetResponseDto(updatedCampaignContribution);
    }
}