using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignCommentsServices;

public class CampaignCommentRetrievalService(
    ICampaignCommentsRepository campaignCommentsRepository,
    CampaignCommentMapper campaignCommentMapper
) : ICampaignCommentRetrievalService
{
    private readonly ICampaignCommentsRepository _campaignCommentsRepository = campaignCommentsRepository;
    private readonly CampaignCommentMapper _campaignCommentMapper = campaignCommentMapper;

    public async Task<Result<CampaignCommentGetResponseDto>> GetCampaignCommentById(string campaignCommentId)
    {
        if (!Guid.TryParse(campaignCommentId, out var parsedCampaignCommentId))
        {
            return new ProblemDetailsError("Invalid ID format");
        }

        var campaignCommentResult = await _campaignCommentsRepository.GetCampaignCommentById(parsedCampaignCommentId);
        if (campaignCommentResult.IsFailed)
        {
            return new ProblemDetailsError(campaignCommentResult.Errors.First().Message);
        }

        return _campaignCommentMapper.MapCampaignCommentToCampaignCommentGetResponseDto(campaignCommentResult.Value);
    }
}

