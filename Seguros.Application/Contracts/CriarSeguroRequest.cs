namespace Seguros.Application.Contracts;

public record CriarSeguroRequest(
    decimal ValorVeiculo,
    string MarcaModeloVeiculo,
    string NomeSegurado,
    string CpfSegurado,
    int IdadeSegurado
);
