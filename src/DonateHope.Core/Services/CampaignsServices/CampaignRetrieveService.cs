using DonateHope.Core.DTOs.CampaignDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignsServices;

public class CampaignRetrieveService(
    ICampaignsRepository campaignsRepository,
    CampaignMapper campaignMapper
) : ICampaignRetrieveService
{
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;
    private readonly CampaignMapper _campaignMapper = campaignMapper;

    public async Task<Result<CampaignGetResponseDto>> GetCampaignByIdAsync(Guid campaignId)
    {
        var campaignResult = await _campaignsRepository.GetCampaignById(campaignId);
        if (campaignResult.IsFailed)
        {
            return new ProblemDetailsError(campaignResult.Errors.First().Message);
        }

        return _campaignMapper.MapCampaignToCampaignGetResponseDto(campaignResult.Value);
    }

    public async Task<Result<IEnumerable<CampaignGetResponseDto>>> GetCampaigns()
    {
        var campaignsListQuery = await _campaignsRepository.GetCampaigns();

        if (campaignsListQuery.IsFailed)
        {
            return new ProblemDetailsError(campaignsListQuery.Errors.First().Message);
        }

        var campaignDtos = campaignsListQuery.Value.Select(
            _campaignMapper.MapCampaignToCampaignGetResponseDto
        );

        return Result.Ok(campaignDtos);
    }
}
