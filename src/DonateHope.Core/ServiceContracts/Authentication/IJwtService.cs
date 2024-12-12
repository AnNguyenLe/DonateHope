using DonateHope.Domain.IdentityEntities;

namespace DonateHope.Core.ServiceContracts.Authentication;

public interface IJwtService
{
    AccessTokenData GenerateAccessToken(AppUser user);
    AccessTokenData GenerateCharityAccessToken(AppUser user);
}
