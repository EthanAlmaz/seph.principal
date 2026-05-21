using Seph.Principal.Domain.Entities;

namespace Seph.Principal.Domain.Repositories
{
    /**
  * Este interface define los métodos para gestionar las sesiones de tokens de actualización.
  * Proporciona métodos para recuperar, agregar y actualizar sesiones de tokens de actualización.
  */
    public interface IRefreshTokenSessionRepository
    {
        Task<RefreshTokenSession?> GetActiveByTokenHashAsync(string tokenHash, CancellationToken cancellationToken);
        Task<IReadOnlyList<RefreshTokenSession>> GetActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task AddAsync(RefreshTokenSession session, CancellationToken cancellationToken);
        void Update(RefreshTokenSession session);
    }
}
