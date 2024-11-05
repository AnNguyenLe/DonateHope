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

    public Task<int> ModifyCampaignContribution(Guid campaignContributionId,
        CampaignContribution updateCampaignContribution)
    {
        throw new NotImplementedException();
    }
}