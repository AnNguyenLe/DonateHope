using DonateHope.Core.Common.ExtensionMethods;
using DonateHope.Core.DTOs.Authentication;
using DonateHope.Core.ServiceContracts.Authentication;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonateHope.WebAPI.Controllers.v1.Account;

[ApiController]
public class RegisterController(
    IValidator<RegistrationRequest> validator,
    IAuthenticationService authenticationService
) : ControllerBase
{
    private readonly IValidator<RegistrationRequest> _validator = validator;
    private readonly IAuthenticationService _authenticationService = authenticationService;

    [Route("api/v1/account/register")]
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<AuthenticationResponse>> Register(RegistrationRequest request)
    {
        var modelValidationResult = _validator.Validate(request);

        if (!modelValidationResult.IsValid)
        {
            return modelValidationResult.Errors.ToValidatingDetailedBadRequest(
                title: "Failed to register new user.",
                detail: "Make sure all the required fields are properly entered."
            );
        }

        var result = await _authenticationService.RegisterNewUserAsync(request);

        if (result.IsFailed)
        {
            return result.Errors.ToDetailedBadRequest();
        }

        return result.Value;
    }
}
