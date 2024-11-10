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

public class CampaignRatingsRepository(
    IDbConnectionFactory dbConnectionFactory,
    ApplicationDbContext applicationDbContext
    ) : ICampaignRatingsRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
    private readonly ApplicationDbContext _dbContext = applicationDbContext;
    public async Task<Result<int>> AddCampaignRating(CampaignRating campaignRating)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         INSERT INTO campaign_ratings
                             (
                                id,
                                rating_point,
                                feedback,
                                created_at,
                                updated_at,
                                created_by,
                                updated_by,
                                is_deleted,
                                user_id,
                                campaign_id
                             )
                         VALUES
                             (
                                @Id,
                                @RatingPoint,
                                @Feedback,
                                @CreatedAt,
                                @UpdatedAt,
                                @CreatedBy,
                                @UpdatedBy,
                                @IsDeleted,
                                @UserId,
                                @CampaignId
                             )
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, campaignRating);
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Failed to add campaign rating.");
        }
        
        return totalAffectedRows;
    }

    public async Task<Result<int>> DeleteCampaignRating(
        Guid campaignRatingId,
        Guid deletedBy
        )
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_ratings
                         SET
                            is_deleted = @isDeleted,
                            deleted_at = @deletedAt,
                            deleted_by = @deletedBy
                         WHERE id = @CampaignRatingId
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(
            sqlCommand,
            new
            {
                isDeleted = true,
                deletedAt = DateTime.UtcNow,
                deletedBy,
                campaignRatingId
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
    public async Task<Result<int>> DeleteCampaignRatingPermanently(Guid CampaignRatingId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         DELETE campaign_ratings
                         WHERE id = @CampaignRatingId;
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, new { CampaignRatingId });
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError(
                $"Unable to permanently delete campaign_rating with ID: {CampaignRatingId}"
            );
        }
        return totalAffectedRows;
    }

    public IQueryable<CampaignRating> GetCampaignRatings(Expression<Func<CampaignRating, bool>> predicate)
    {
        return _dbContext.CampaignRatings.Where(predicate);
    }

    public async Task<Result<CampaignRating>> GetCampaignRatingById(Guid campaignRatingId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var queryResult = await _dbContext
            .CampaignRatings.Where(cr => cr.Id == campaignRatingId)
            .FirstOrDefaultAsync();
        if (queryResult is null)
        {
            return new ProblemDetailsError($"CampaignRating with ID: {campaignRatingId} not found.");
        }

        return queryResult;
    }

    public async Task<Result<int>> UpdateCampaignRating(CampaignRating updateCampaignRating)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_ratings
                         SET
                             rating_point = @RatingPoint,
                             feedback = @Feedback,
                             updated_at = @UpdatedAt,
                             updated_by = @UpdatedBy
                         WHERE 
                             id = @Id;
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, updateCampaignRating);
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Unable to update campaign_rating.");
        }
        return totalAffectedRows;
    }
}