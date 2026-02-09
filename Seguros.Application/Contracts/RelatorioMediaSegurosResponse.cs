namespace Seguros.Application.Contracts;

public record RelatorioMediaSegurosResponse(
    int QuantidadeSeguros,
    decimal MediaValorSeguro
);
