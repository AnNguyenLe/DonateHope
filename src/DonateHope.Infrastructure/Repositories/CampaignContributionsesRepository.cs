using System.Data;
using Dapper;
using DonateHope.Core.Errors;
using DonateHope.Domain.Entities;
using DonateHope.Domain.RepositoryContracts;
using DonateHope.Infrastructure.Data;
using FluentResults;

namespace DonateHope.Infrastructure.Repositories;

public class CampaignContributionsesRepository(IDbConnectionFactory dbConnectionFactory) : ICampaignContributionsRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

    public async Task<int> AddCampaignContribution(CampaignContribution campaignContribution)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         INSERT INTO campaign_contributions
                             (
                                id,
                                amount,
                                unit_of_measurement,
                                contribution_method,
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
                                @Amount,
                                @UnitOfMeasurement,
                                @ContributionMethod,
                                @CreatedAt,
                                @UpdatedAt,
                                @CreatedBy,
                                @UpdatedBy,
                                @IsDeleted,
                                @UserId,
                                @CampaignId
                             )
                         """;
        return await dbConnection.ExecuteAsync(sqlCommand, campaignContribution);
    }

    public async Task<int> DeleteCampaignContribution(Guid campaignContributionId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_contributions
                         SET
                            end_date = @endDate;
                            updated_at = @updatedAt;
                            updated_by = @updatedBy;
                            is_deleted = @isDeleted;
                            deleted_at = @deletedAt;
                            deleted_by = @deletedBy;
                         WHERE id = @campaignContributionId
                         """;
        return await dbConnection.ExecuteAsync(
            sqlCommand,
            new { endDate = DateTime.UtcNow, updated_at = DateTime.UtcNow});
    }
    
    public Task<int> DeleteCampaignContributionPermanently(Guid campaignContributionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CampaignContribution>> GetCampaignContributions()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CampaignContribution>> GetCampaignContributions(Func<CampaignContribution, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CampaignContribution>> GetCampaignContributionById(Guid campaignContributionId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         SELECT *
                         FROM campaign_contributions
                         WHERE
                            id = @campaignContributionId
                            AND is_deleted = false
                         """;
        var queryResult = await dbConnection.QueryFirstOrDefaultAsync<CampaignContribution>(
            sqlCommand,
            new { campaignContributionId }
            );
        if (queryResult is null)
        {
            return new ProblemDetailsError($"CampaignContribution with ID: {campaignContributionId} not found.");
        }
        return queryResult;
    }

    public Task<int> ModifyCampaignContribution(Guid campaignContributionId,
        CampaignContribution updateCampaignContribution)
    {
        throw new NotImplementedException();
    }
}