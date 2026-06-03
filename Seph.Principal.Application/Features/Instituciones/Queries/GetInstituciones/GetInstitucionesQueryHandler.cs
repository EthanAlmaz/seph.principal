using MediatR;
using Seph.Principal.Application.Common.Models;
using Seph.Principal.Domain.Repositories;

namespace Seph.Principal.Application.Features.Instituciones.Queries.GetInstituciones
{
    public sealed class GetInstitucionesQueryHandler(IInstitucionRepository institucionRepository)
     : IRequestHandler<GetInstitucionesQuery,ResponseWrapper<IReadOnlyList<InstitucionDto>>>
    {
        public async Task<ResponseWrapper<IReadOnlyList<InstitucionDto>>>Handle(GetInstitucionesQuery request,CancellationToken cancellationToken)
        {
            var instituciones = await institucionRepository.GetAllAsync(cancellationToken);

            IReadOnlyList<InstitucionDto> response = instituciones.Select(x => new InstitucionDto(
                        x.Id,
                        x.StrValor,
                        x.StrDescripcion))
                    .ToList();

            return ResponseFactory.Success(
                response,
                "Instituciones obtenidas correctamente");
        }
    }
}
