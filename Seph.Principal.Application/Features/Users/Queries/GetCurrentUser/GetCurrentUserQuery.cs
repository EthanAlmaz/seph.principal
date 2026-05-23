using MediatR;
using Seph.Principal.Application.Common.Models;
using Seph.Principal.Application.Features.Auth.DTOs;

namespace Seph.Principal.Application.Features.Users.Queries.GetCurrentUser
{
    public sealed record GetCurrentUserQuery(Guid UserId):IRequest<ResponseWrapper<UserSessionDto>>;
    
    
}
