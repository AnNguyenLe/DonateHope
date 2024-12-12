using DonateHope.Core.DTOs.Authentication;
using FluentResults;

namespace DonateHope.Core.ServiceContracts.Authentication;

public interface IAuthenticationService
{
    Task<Result<AuthenticationResponse>> RegisterNewUserAsync(RegistrationRequest request);
    Task<Result<AuthenticationResponse>> ConfirmEmailUserRegistrationAsync(
        EmailConfirmationRequest request
    );
    Task<Result<AuthenticationResponse>> LogInAsync(LogInRequest request);
    Task<Result> LogOutAsync();
    Task<Result> ForgotPasswordAsync(ForgotPasswordRequest request);

    Task<Result> ResetPasswordAsync(ResetPasswordRequest request);
    Task<Result<AuthenticationResponse>> RegisterAsCharityAsync(
        RegistrationAsCharityRequest request
    );
}
