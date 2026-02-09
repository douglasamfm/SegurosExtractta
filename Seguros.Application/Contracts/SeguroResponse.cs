namespace Seguros.Application.Contracts;

public record SeguroResponse(
    Guid Id,
    decimal ValorVeiculo,
    string MarcaModeloVeiculo,
    string NomeSegurado,
    string CpfSegurado,
    int IdadeSegurado,
    decimal ValorSeguro
);
