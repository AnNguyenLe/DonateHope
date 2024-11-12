using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignCommentsServices;

public class CampaignCommentRetrieveService(
    ICampaignCommentsRepository campaignCommentsRepository,
    CampaignCommentMapper campaignCommentMapper
) : ICampaignCommentRetrieveService
{
    private readonly ICampaignCommentsRepository _campaignCommentsRepository = campaignCommentsRepository;
    private readonly CampaignCommentMapper _campaignCommentMapper = campaignCommentMapper;

    public async Task<Result<CampaignCommentGetResponseDto>> GetCampaignCommentById(Guid campaignCommentId)
    {
      

        var campaignCommentResult = await _campaignCommentsRepository.GetCampaignCommentById(campaignCommentId);
        if (campaignCommentResult.IsFailed)
        {
            return new ProblemDetailsError(campaignCommentResult.Errors.First().Message);
        }

        return _campaignCommentMapper.MapCampaignCommentToCampaignCommentGetResponseDto(campaignCommentResult.Value);
    }
}

