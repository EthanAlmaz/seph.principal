using Seph.Principal.Application.Features.Auth.DTOs;

namespace Seph.Principal.Application.Common.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateAccessToken(AuthenticatedUserDto user);

        string CreateRefreshToken();

        string HashRefreshToken(string refreshToken);
    }
}
