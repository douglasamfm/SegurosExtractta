namespace Seguros.Domain.Services;

public static class CalculadoraSeguro
{
    private const decimal MARGEM_SEGURANCA = 0.03m; // 3%
    private const decimal LUCRO = 0.05m;            // 5%

    public static decimal Calcular(decimal valorVeiculo)
    {
        if (valorVeiculo <= 0)
            throw new ArgumentException("O valor do veículo deve ser maior que zero.");

        // Taxa de risco = (Valor do Veículo * 5) / (2 x Valor do Veículo)
        var taxaRisco = 5m / 2m;

        var premioRisco = taxaRisco * valorVeiculo;
        var premioPuro = premioRisco * (1 + MARGEM_SEGURANCA);
        var premioComercial = premioPuro * (1 + LUCRO);

        return Math.Round(premioComercial, 2, MidpointRounding.AwayFromZero);
    }
}
