using System.Net.Mail;
using DonateHope.Core.ServiceContracts.Authentication;
using DonateHope.Core.ServiceContracts.Email;
using DonateHope.Core.ServiceContracts.HtmlTemplate;
using DonateHope.Core.Services.Authentication;
using DonateHope.Core.Services.EmailService;
using DonateHope.Core.Services.HtmlTemplate;
using DonateHope.Core.Validators.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DonateHope.WebAPI.StartupExtensions;

public static class DependencyInjectionServicesExtension
{
    public static IServiceCollection DependencyInjectionServices(this IServiceCollection services)
    {
        services.TryAddScoped<IJwtService, JwtService>();
        services.TryAddScoped<IAuthenticationService, AuthenticationService>();
        services.TryAddScoped<IEmailHtmlTemplateService, EmailHtmlTemplateService>();
        services.TryAddScoped<IEmailSenderService, EmailSenderService>();
        services.TryAddScoped<ISmtpClientProvider, SmtpClientProvider>();

        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

        return services;
    }
}
