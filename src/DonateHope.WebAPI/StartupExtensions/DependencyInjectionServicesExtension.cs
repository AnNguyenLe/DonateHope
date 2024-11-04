using DonateHope.Core.Mappers;
using DonateHope.Core.ServiceContracts.Authentication;
using DonateHope.Core.ServiceContracts.CampaignContributionsServiceContracts;
using DonateHope.Core.ServiceContracts.CampaignsServiceContracts;
using DonateHope.Core.ServiceContracts.Email;
using DonateHope.Core.ServiceContracts.HtmlTemplate;
using DonateHope.Core.Services.Authentication;
using DonateHope.Core.Services.CampaignContributionServices;
using DonateHope.Core.Services.CampaignsServices;
using DonateHope.Core.Services.EmailService;
using DonateHope.Core.Services.HtmlTemplate;
using DonateHope.Core.Validators.Authentication;
using DonateHope.Domain.RepositoryContracts;
using DonateHope.Infrastructure.Data;
using DonateHope.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DonateHope.WebAPI.StartupExtensions;

public static class DependencyInjectionServicesExtension
{
    public static IServiceCollection DependencyInjectionServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.TryAddScoped<IJwtService, JwtService>();
        services.TryAddScoped<IAuthenticationService, AuthenticationService>();
        services.TryAddScoped<IEmailHtmlTemplateService, EmailHtmlTemplateService>();
        services.TryAddScoped<IEmailSenderService, EmailSenderService>();
        services.TryAddScoped<ISmtpClientProvider, SmtpClientProvider>();

        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

        services.TryAddSingleton<IDbConnectionFactory>(_ => new NpgsqlDbConnectionFactory(
            configuration.GetConnectionString("Default")!
        ));

        services.TryAddSingleton<ICampaignsRepository, CampaignsRepository>();
        services.TryAddSingleton<CampaignMapper>();
        services.TryAddScoped<ICampaignCreatingService, CampaignCreatingService>();
        services.TryAddScoped<ICampaignRetrievalService, CampaignRetrievalService>();
        services.TryAddScoped<ICampaignUpdatingService, CampaignUpdatingService>();
        
        services.TryAddSingleton<ICampaignContributionsRepository, CampaignContributionsesRepository>();
        services.TryAddScoped<CampaignContributionMapper>();
        services.TryAddScoped<ICampaignContributionCreatingService, CampaignContributionCreatingService>();
        services.TryAddScoped<ICampaignContributionRetrievalService, CampaignContributionRetrievalService>();

        return services;
    }
}
