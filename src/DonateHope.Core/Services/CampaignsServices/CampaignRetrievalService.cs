using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignsServices;

public class CampaignRetrievalService(
    ICampaignsRepository campaignsRepository,
    CampaignMapper campaignMapper
) : ICampaignRetrievalService
{
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;
    private readonly CampaignMapper _campaignMapper = campaignMapper;

    public async Task<Result<CampaignGetResponseDto>> GetCampaignById(string campaignId)
    {
        if (!Guid.TryParse(campaignId, out var parsedCampaignId))
        {
            return new ProblemDetailsError("Invalid ID format");
        }

        var campaignResult = await _campaignsRepository.GetCampaignById(parsedCampaignId);
        if (campaignResult.IsFailed)
        {
            return new ProblemDetailsError(campaignResult.Errors.First().Message);
        }

        return _campaignMapper.MapCampaignToCampaignGetResponseDto(campaignResult.Value);
    }
}
