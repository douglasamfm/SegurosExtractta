using Microsoft.EntityFrameworkCore;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Infrastructure.Data;

namespace Seguros.Infrastructure.Repositories;

public class SeguroRepository : ISeguroRepository
{
    private readonly SegurosDbContext _db;

    public SeguroRepository(SegurosDbContext db)
    {
        _db = db;
    }


    public async Task AddAsync(Seguro seguro, CancellationToken ct)
    {
        var entity = new SeguroEntity
        {
            Id = seguro.Id,
            ValorVeiculo = seguro.Veiculo.Valor,
            MarcaModeloVeiculo = seguro.Veiculo.MarcaModelo,
            NomeSegurado = seguro.Segurado.Nome,
            CpfSegurado = seguro.Segurado.Cpf,
            IdadeSegurado = seguro.Segurado.Idade,
            ValorSeguro = seguro.ValorSeguro
        };

        _db.Seguros.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<Seguro?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var e = await _db.Seguros.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);

        if (e is null) return null;

        var veiculo = new Veiculo(e.ValorVeiculo, e.MarcaModeloVeiculo);
        var segurado = new Segurado(e.NomeSegurado, e.CpfSegurado, e.IdadeSegurado);

   
        return new Seguro(e.Id, veiculo, segurado, e.ValorSeguro);
    }

    public async Task<List<Seguro>> GetAllAsync(CancellationToken ct)
    {
        var list = await _db.Seguros.AsNoTracking().ToListAsync(ct);

        return list.Select(e =>
        {
            var veiculo = new Veiculo(e.ValorVeiculo, e.MarcaModeloVeiculo);
            var segurado = new Segurado(e.NomeSegurado, e.CpfSegurado, e.IdadeSegurado);

            return new Seguro(e.Id, veiculo, segurado, e.ValorSeguro);
        }).ToList();
    }
}
