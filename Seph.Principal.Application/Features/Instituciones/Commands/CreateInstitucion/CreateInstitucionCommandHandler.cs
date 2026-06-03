using MediatR;
using Seph.Principal.Application.Common.Interfaces;
using Seph.Principal.Application.Common.Models;
using Seph.Principal.Domain.Entities;
using Seph.Principal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seph.Principal.Application.Features.Instituciones.Commands.CreateInstitucion
{
    public sealed class CreateInstitucionCommandHandler(IInstitucionRepository institucionRepository,
     IUnitOfWork unitOfWork): IRequestHandler<CreateInstitucionCommand,ResponseWrapper<InstitucionDto>>
    {
        public async Task<ResponseWrapper<InstitucionDto>> Handle(CreateInstitucionCommand request,CancellationToken cancellationToken)
        {
            var institucion = new Institucion
            {
                StrValor = request.StrValor,
                StrDescripcion = request.StrDescripcion
            };

            await institucionRepository.AddAsync(institucion,cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = new InstitucionDto(institucion.Id,institucion.StrValor,institucion.StrDescripcion);

            return ResponseFactory.Success(
                dto,
                "Institución registrada correctamente");
        }
    }
}
