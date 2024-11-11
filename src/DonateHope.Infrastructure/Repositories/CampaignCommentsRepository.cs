using Dapper;
using DonateHope.Core.Errors;
using DonateHope.Domain.Entities;
using DonateHope.Domain.RepositoryContracts;
using DonateHope.Infrastructure.Data;
using FluentResults;

namespace DonateHope.Infrastructure.Repositories;

public class CampaignCommentsRepository(IDbConnectionFactory dbConnectionFactory) : ICampaignCommentsRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

    public async Task<int> AddCampaignComment(CampaignComment campaignComment)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                INSERT INTO campaign_comments 
                    (
                        id,
                        content, 
                        created_at, 
                        updated_at, 
                        created_by, 
                        updated_by,
                        is_deleted,
                        deleted_at,
                        deleted_by,
                        is_banned, 
                        user_id,
                        campaign_id
                    )
                VALUES 
                    (
                        @Id,
                        @Content,  
                        @CreatedAt,     
                        @UpdatedAt,
                        @CreatedBy,
                        @UpdatedBy,
                        @IsDeleted,
                        @DeletedAt,
                        @DeletedBy,
                        @IsBanned,
                        @UserId,
                        @CampaignId
                    );
            """;

        // TODO: Update campaign_log also
        return await dbConnection.ExecuteAsync(sqlCommand, campaignComment);
    }


    public Task<IEnumerable<CampaignComment>> GetCampaignComments()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CampaignComment>> GetCampaignComments(Func<CampaignComment, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CampaignComment>> GetCampaignCommentById(Guid campaignCommentId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();

        var sqlCommand = """
                SELECT *
                FROM campaign_comments
                WHERE 
                    id = @campaignCommentId
                    AND is_deleted = false
            """;

        var queryResult = await dbConnection.QueryFirstOrDefaultAsync<CampaignComment>(
            sqlCommand,
            new { campaignCommentId }
        );

        if (queryResult is null)
        {
            return new ProblemDetailsError($"Campaign Comment with ID: {campaignCommentId} not found.");
        }

        return queryResult;
    }

    public async Task<Result<int>> UpdateCampaignComment(CampaignComment updatedCampaignComment)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();

        var sqlCommand = """
                UPDATE campaign_comments
                SET
                    content = @Content, 
                    updated_at = @UpdatedAt,
                    updated_by = @UpdatedBy,
                    campaign_id = @CampaignId,
                    user_id = @UserId
                WHERE
                    id = @Id;
            """;

        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, updatedCampaignComment);

        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Unable to update the campaign comment.");
        }

        return totalAffectedRows;
    }
    public async Task<Result<int>> DeleteCampaigCommentPermanently(Guid campaignCommentId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();

        var sqlCommand = """
                DELETE campaign_comments
                WHERE id = @campaignCommentId;
            """;

        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, new { campaignCommentId });

        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError(
                $"Unable to permanently delete campaign with ID: {campaignCommentId}"
            );
        }

        return totalAffectedRows;
    }

    public Task<int> DeleteCampaignComment(Guid campaignCommentId)
    {
        throw new NotImplementedException();
    }
}
