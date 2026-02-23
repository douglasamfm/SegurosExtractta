using Seguros.Application.Contracts;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Services;

namespace Seguros.Application.UseCases;

public class SeguroService
{
    private readonly ISeguroRepository _repo;

    public SeguroService(ISeguroRepository repo)
    {
        _repo = repo;
    }

    public async Task<SeguroResponse> CriarAsync(CriarSeguroRequest req, CancellationToken ct)
    {
        var veiculo = new Veiculo(req.ValorVeiculo, req.MarcaModeloVeiculo);
        var segurado = new Segurado(req.NomeSegurado, req.CpfSegurado, req.IdadeSegurado);

        var valorSeguro = CalculadoraSeguro.Calcular(veiculo.Valor);

        var seguro = new Seguro(veiculo, segurado, valorSeguro);

        await _repo.AddAsync(seguro, ct);

        return new SeguroResponse(
            seguro.Id,
            seguro.Veiculo.Valor,
            seguro.Veiculo.MarcaModelo,
            seguro.Segurado.Nome,
            seguro.Segurado.Cpf,
            seguro.Segurado.Idade,
            seguro.ValorSeguro
        );
    }

    public async Task<SeguroResponse?> ObterPorIdAsync(Guid id, CancellationToken ct)
    {
        var seguro = await _repo.GetByIdAsync(id, ct);
        if (seguro is null) return null;

        return new SeguroResponse(
            seguro.Id,
            seguro.Veiculo.Valor,
            seguro.Veiculo.MarcaModelo,
            seguro.Segurado.Nome,
            seguro.Segurado.Cpf,
            seguro.Segurado.Idade,
            seguro.ValorSeguro
        );
    }

    public async Task<RelatorioMediaSegurosResponse> ObterMediaAsync(CancellationToken ct)
    {
        var seguros = await _repo.GetAllAsync(ct);

        if (seguros.Count == 0)
            return new RelatorioMediaSegurosResponse(0, 0, 0);

        var mediaSeguro = seguros.Average(s => s.ValorSeguro);
        var mediaVeiculo = seguros.Average(s => s.Veiculo.Valor);

        return new RelatorioMediaSegurosResponse(
            seguros.Count,
            Math.Round(mediaSeguro, 2, MidpointRounding.AwayFromZero),
            Math.Round(mediaVeiculo, 2, MidpointRounding.AwayFromZero)
        );
    }

    public async Task<List<SeguroResponse>> ListarAsync(CancellationToken ct)
    {
        var seguros = await _repo.GetAllAsync(ct);

        return seguros.Select(seguro => new SeguroResponse(
            seguro.Id,
            seguro.Veiculo.Valor,
            seguro.Veiculo.MarcaModelo,
            seguro.Segurado.Nome,
            seguro.Segurado.Cpf,
            seguro.Segurado.Idade,
            seguro.ValorSeguro
        )).ToList();
    }
}
