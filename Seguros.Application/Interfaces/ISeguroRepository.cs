using Seguros.Domain.Entities;

namespace Seguros.Application.Interfaces;

public interface ISeguroRepository
{
    Task AddAsync(Seguro seguro, CancellationToken ct);
    Task<Seguro?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<List<Seguro>> GetAllAsync(CancellationToken ct);

}
