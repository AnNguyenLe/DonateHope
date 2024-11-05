using DonateHope.Core.DTOs.CampaignContributionDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Domain.Entities;
using DonateHope.Domain.EntityExtensions;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignContributionServices;

public class CampaignContributionCreatingService(
    ICampaignContributionsRepository campaignContributionsRepository,
    CampaignContributionMapper campaignContributionMapper
    ) : ICampaignContributionCreatingService
{
    private readonly ICampaignContributionsRepository
        _campaignContributionsRepository = campaignContributionsRepository;
    private readonly CampaignContributionMapper _campaignContributionMapper = campaignContributionMapper;

    public async Task<Result<CampaignContribution>> CreateCampaignContributionAsync(
        CampaignContributionCreateRequestDto campaignContributionCreateRequestDto,
        string userId
    )
    {
        var campaignContribution = _campaignContributionMapper
            .MapCampaignContributionCreateRequestDtoToCampaignContribution(campaignContributionCreateRequestDto)
            .OnNewCampaignContributionCreating(Guid.Parse(userId));
        
        var affectedRows = await _campaignContributionsRepository.AddCampaignContribution(campaignContribution);
        if (affectedRows == 0)
        {
            return new ProblemDetailsError("Failed to create campaign contribution");
        }
        return campaignContribution;
    }
}