using System.Linq.Expressions;
using Dapper;
using DonateHope.Core.Errors;
using DonateHope.Domain.Entities;
using DonateHope.Domain.RepositoryContracts;
using DonateHope.Infrastructure.Data;
using DonateHope.Infrastructure.DbContext;
using FluentResults;
using Microsoft.EntityFrameworkCore;
namespace DonateHope.Infrastructure.Repositories;

public class CampaignCommentsRepository(IDbConnectionFactory dbConnectionFactory, ApplicationDbContext applicationDbContext) : ICampaignCommentsRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
    private readonly ApplicationDbContext _dbContext = applicationDbContext;

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

    public async Task<IEnumerable<CampaignComment>> GetCommentsByCampaignId(Guid campaignId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
        SELECT 
            id,
            content, 
            created_at AS CreatedAt, 
            updated_at AS UpdatedAt, 
            created_by AS CreatedBy, 
            updated_by AS UpdatedBy,
            is_deleted AS IsDeleted,
            deleted_at AS DeletedAt,
            deleted_by AS DeletedBy,
            is_banned AS IsBanned, 
            user_id AS UserId,
            campaign_id AS CampaignId
        FROM 
            campaign_comments
        WHERE 
            campaign_id = @CampaignId
            AND is_deleted = false
        ORDER BY 
            created_at DESC;
    """;

        var comments = await dbConnection.QueryAsync<CampaignComment>(
            sqlCommand,
            new { CampaignId = campaignId }
        );

        return comments;
    }

    public async Task<Result<CampaignComment>> GetCampaignCommentById(Guid campaignCommentId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var queryResult = await _dbContext
            .CampaignComments.Where(cc => cc.Id == campaignCommentId)
            .FirstOrDefaultAsync();
        if (queryResult is null)
        {
            return new ProblemDetailsError($"Campaign Comment with ID: {campaignCommentId} not found.");
        }

        return queryResult;
    }

    public async Task<Result<int>> UpdateCampaignComment(CampaignComment updateCampaignComment)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_comments
                         SET
                             content = @Content,
                             updated_at = @UpdatedAt,
                             updated_by = @UpdatedBy
                         WHERE 
                             id = @Id;
                             
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, updateCampaignComment);
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Unable to update campaign_contribution.");
        }
        return totalAffectedRows;
    }


    public async Task<Result<int>> DeleteCampaignComment(
        Guid campaignCommentId, Guid deletedBy
        )
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_comments
                         SET
                            is_deleted = @isDeleted,
                            deleted_at = @deletedAt,
                            deleted_by = @deletedBy
                         WHERE id = @campaignCommentId
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(
            sqlCommand,
            new
            {
                isDeleted = true,
                deletedAt = DateTime.UtcNow,
                deletedBy,
                campaignCommentId
            });
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Something wrong trying to delete this record.");
        }

        return totalAffectedRows;
    }

    /// <summary>
    /// USING THIS WITH CAUTION! Your data will be deleted permanently and will not be able to recovered!
    /// </summary>
    public async Task<Result<int>> DeleteCampaignCommentPermanently(Guid campaignCommentId)
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
                $"Unable to permanently delete campaign_contribution with ID: {campaignCommentId}"
            );
        }
        return totalAffectedRows;
    }


}
