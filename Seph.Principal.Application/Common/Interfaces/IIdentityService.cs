using Seph.Principal.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seph.Principal.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticatedUserDto> ValidateCredentialAsync(string email, string password, CancellationToken cancellationToken);
        Task<AuthenticatedUserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<string>> GetUserPermissionsAsync(Guid userId, CancellationToken cancellationToken);

        Task MarkLastLoginAsync(Guid userId, CancellationToken cancellationToken);
    }
}
