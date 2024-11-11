using DonateHope.Core.DTOs.CampaignCommentDTOs;
using DonateHope.Core.Errors;
using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.CampaignCommentServiceContracts;
using DonateHope.Domain.Entities;
using DonateHope.Domain.EntityExtensions;
using DonateHope.Domain.RepositoryContracts;
using FluentResults;

namespace DonateHope.Core.Services.CampaignCommentsServices;

public class CampaignCommentUpdateService(
    ICampaignCommentsRepository campaignCommentsRepository,
    CampaignCommentMapper campaignCommentMapper
) : ICampaignCommentUpdateService
{
    private readonly CampaignCommentMapper _campaignCommentMapper = campaignCommentMapper;
    private readonly ICampaignCommentsRepository _campaignCommentsRepository = campaignCommentsRepository;

    public async Task<Result> UpdateCampaignCommentAsync(
        CampaignCommentUpdateRequestDto updateCommentRequestDto,
        Guid userId
    )
    {
        var queryResult = await _campaignCommentsRepository.GetCampaignCommentById(updateCommentRequestDto.Id);

        if (queryResult.IsFailed || queryResult.ValueOrDefault is null)
        {
            return new ProblemDetailsError("Campaign Comment not available.");
        }

        var currentCampaignComment = queryResult.Value;

        if (userId != currentCampaignComment.UserId)
        {
            return new ProblemDetailsError("You are not the owner of this campaign comment.");
        }

        var updatedCampaignComment = _campaignCommentMapper.MapCampaignCommentUpdateRequestDtoToCampaignComment(
            updateCommentRequestDto
        );
        // updatedCampaignComment.UserId = userId;
        // updatedCampaignComment.CampaignId = currentCampaignComment.CampaignId;
        updatedCampaignComment.Content = updateCommentRequestDto.Content;
        updatedCampaignComment.UpdatedAt = DateTime.UtcNow;
        // updatedCampaignComment.UpdatedBy = userId;

        var updateResult = await _campaignCommentsRepository.UpdateCampaignComment(updatedCampaignComment);
        if (updateResult.IsFailed)
        {
            return new ProblemDetailsError("Failed to update campaign comment.");
        }

        return Result.Ok();

    }

}
