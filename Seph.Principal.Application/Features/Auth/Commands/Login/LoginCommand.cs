using MediatR;
using Seph.Principal.Application.Common.Models;
using Seph.Principal.Application.Features.Auth.DTOs;

namespace Seph.Principal.Application.Features.Auth.Commands.Login
{
    public sealed record LoginCommand(string Email, string Password, string DeviceId, string IpAddress):
        IRequest<ResponseWrapper<AuthResponseDto>>;
    
    
}
