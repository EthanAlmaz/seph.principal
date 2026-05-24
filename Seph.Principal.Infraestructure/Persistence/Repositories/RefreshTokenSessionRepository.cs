using Microsoft.EntityFrameworkCore;
using Seph.Principal.Domain.Entities;
using Seph.Principal.Domain.Enums;
using Seph.Principal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seph.Principal.Infraestructure.Persistence.Repositories
{
    public sealed class RefreshTokenSessionRepository(ApplicationDbContext dbContext): IRefreshTokenSessionRepository
    {
        public Task<RefreshTokenSession?> GetActiveByTokenHashAsync(string tokenHash, CancellationToken cancellationToken)
            => dbContext.RefreshTokenSessions
            .FirstOrDefaultAsync(
                session => session.TokenHash == tokenHash
                && session.Status == SessionStatus.Active &&
                session.ExpiresAtUtc > DateTimeOffset.UtcNow,
                cancellationToken);
        public async Task<IReadOnlyList<RefreshTokenSession>> GetActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        => await dbContext.RefreshTokenSessions
            .Where(session => session.UserId == userId
                && session.Status == SessionStatus.Active
                && session.ExpiresAtUtc > DateTimeOffset.UtcNow)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        public Task AddAsync(RefreshTokenSession session, CancellationToken cancellationToken)
        => dbContext.RefreshTokenSessions.AddAsync(session, cancellationToken).AsTask();

        public void Update(RefreshTokenSession session)
            => dbContext.RefreshTokenSessions.Update(session);

    }
}
