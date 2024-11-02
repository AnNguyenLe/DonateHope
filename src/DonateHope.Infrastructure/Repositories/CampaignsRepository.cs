using Dapper;
using DonateHope.Core.Errors;
using DonateHope.Domain.Entities;
using DonateHope.Domain.RepositoryContracts;
using DonateHope.Infrastructure.Data;
using FluentResults;

namespace DonateHope.Infrastructure.Repositories;

public class CampaignsRepository(IDbConnectionFactory dbConnectionFactory) : ICampaignsRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

    public async Task<int> AddCampaign(Campaign campaign)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                INSERT INTO campaigns 
                    (
                        id, 
                        title, 
                        subtitle, 
                        summary, 
                        description, 
                        goal_amount,
                        achieved_amount,
                        unit_of_measurement,
                        goal_status,
                        expecting_start_date, 
                        expecting_end_date, 
                        number_of_ratings,
                        average_rating_point,
                        spending_amount,
                        created_at, 
                        updated_at,
                        created_by, 
                        updated_by, 
                        is_active,
                        is_deleted,
                        user_id
                    )
                VALUES 
                    (
                        @Id, 
                        @Title, 
                        @Subtitle, 
                        @Summary, 
                        @Description, 
                        @GoalAmount,
                        @AchievedAmount,
                        @UnitOfMeasurement, 
                        @GoalStatus,
                        @ExpectingStartDate, 
                        @ExpectingEndDate,
                        @NumberOfRatings,
                        @AverageRatingPoint,
                        @SpendingAmount,
                        @CreatedAt,
                        @UpdatedAt,
                        @CreatedBy,
                        @UpdatedBy,
                        @IsActive,
                        @IsDeleted,
                        @UserId
                    );
            """;

        // TODO: Update campaign_log also
        return await dbConnection.ExecuteAsync(sqlCommand, campaign);
    }

    public async Task<int> DeleteCampaign(Guid campaignId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();

        var sqlCommand = """
                UPDATE campaigns
                SET
                    end_date = @endDate,
                    updated_at = @updatedAt,
                    updated_by = @updatedBy,
                    is_deleted = @isDeleted,
                    deleted_at = @deletedAt,
                    deleted_by = @deletedBy,
                    is_active = @isActive,
                    active_status_note = @activeStatusNote
                WHERE id = @campaignId
            """;

        // TODO: Update campaign_log also
        return await dbConnection.ExecuteAsync(
            sqlCommand,
            new { endDate = DateTime.UtcNow, updatedAt = DateTime.UtcNow, }
        );
    }

    public Task<int> DeleteCampaignPermanently(Guid campaignId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Campaign>> GetCampaigns()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Campaign>> GetCampaigns(Func<Campaign, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Campaign>> GetCampaignById(Guid campaignId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();

        var sqlCommand = """
                SELECT *
                FROM campaigns
                WHERE 
                    id = @campaignId
                    AND is_deleted = false
            """;

        var queryResult = await dbConnection.QueryFirstOrDefaultAsync<Campaign>(
            sqlCommand,
            new { campaignId }
        );

        if (queryResult is null)
        {
            return new ProblemDetailsError($"Campaign with ID: {campaignId} not found.");
        }

        return queryResult;
    }

    public Task<int> ModifyCampaign(Guid campaignId, Campaign updatedCampaign)
    {
        throw new NotImplementedException();
    }
}
