using System.Data;
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

public class CampaignContributionsesRepository(
    IDbConnectionFactory dbConnectionFactory,
    ApplicationDbContext applicationDbContext
    ) : ICampaignContributionsRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
    private readonly ApplicationDbContext _dbContext = applicationDbContext;
    public async Task<Result<int>> AddCampaignContribution(CampaignContribution campaignContribution)
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
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, campaignContribution);
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Failed to add campaign contribution.");
        }
        
        return totalAffectedRows;
    }

    public async Task<Result<int>> DeleteCampaignContribution(
        Guid campaignContributionId,
        Guid deletedBy,
        string reasonForDeletion
        )
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_contributions
                         SET
                            is_deleted = @isDeleted;
                            deleted_at = @deletedAt;
                            deleted_by = @deletedBy;
                         WHERE id = @campaignContributionId
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(
            sqlCommand,
            new
            {
                isDeleted = true,
                deletedAt = DateTime.UtcNow,
                deletedBy
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
    public async Task<Result<int>> DeleteCampaignContributionPermanently(Guid campaignContributionId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         DELETE campaign_contributions
                         WHERE id = @campaignContributionId;
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, new { campaignContributionId });
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError(
                $"Unable to permanently delete campaign_contribution with ID: {campaignContributionId}"
            );
        }
        return totalAffectedRows;
    }

    public IQueryable<CampaignContribution> GetCampaignContributions(Expression<Func<CampaignContribution, bool>> predicate)
    {
        return _dbContext.CampaignContributions.Where(predicate);
    }

    public async Task<Result<CampaignContribution>> GetCampaignContributionById(Guid campaignContributionId)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var queryResult = await _dbContext
            .CampaignContributions.Where(cc => cc.Id == campaignContributionId)
            .FirstOrDefaultAsync();
        if (queryResult is null)
        {
            return new ProblemDetailsError($"CampaignContribution with ID: {campaignContributionId} not found.");
        }

        return queryResult;
    }

    public async Task<Result<int>> UpdateCampaignContribution(CampaignContribution updateCampaignContribution)
    {
        using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
        var sqlCommand = """
                         UPDATE campaign_contributions
                         SET
                             amount = @Amount,
                             unit_of_measurement = @UnitOfMeasurement,
                             contribution_method = @ContributionMethod,
                             updated_at = @UpdatedAt,
                             updated_by = @UpdatedBy
                         WHERE 
                             id = @Id;
                         """;
        var totalAffectedRows = await dbConnection.ExecuteAsync(sqlCommand, updateCampaignContribution);
        if (totalAffectedRows == 0)
        {
            return new ProblemDetailsError("Unable to update campaign_contribution.");
        }
        return totalAffectedRows;
    }
}