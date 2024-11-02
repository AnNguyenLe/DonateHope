using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Domain.Entities;
using DonateHope.Domain.EntityExtensions;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignsServices;

public class CampaignCreatingService(
    ICampaignsRepository campaignsRepository,
    CampaignMapper campaignMapper
) : ICampaignCreatingService
{
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;
    private readonly CampaignMapper _campaignMapper = campaignMapper;

    public async Task<Result<Campaign>> CreateCampaignAsync(
        CampaignCreateRequestDto campaignCreateRequestDto,
        string userId
    )
    {
        var campaign = _campaignMapper
            .MapCampaignCreateRequestDtoToCampaign(campaignCreateRequestDto)
            .OnNewCampaignCreating(Guid.Parse(userId));

        var affectedRows = await _campaignsRepository.AddCampaign(campaign);
        if (affectedRows == 0)
        {
            return new ProblemDetailsError("Failed to create campaign");
        }
        return campaign;
    }
}
