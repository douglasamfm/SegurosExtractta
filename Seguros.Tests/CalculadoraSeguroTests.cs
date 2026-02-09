using Seguros.Domain.Services;
using Xunit;

namespace Seguros.Tests.Unit;

public class CalculadoraSeguroTests
{
    [Fact]
    public void Calcular_ValorVeiculo10000_DeveRetornarValorEsperado()
    {
        var resultado = CalculadoraSeguro.Calcular(10000m);

        Assert.Equal(270.37m, resultado);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Calcular_ValorVeiculoInvalido_DeveLancarExcecao(decimal valor)
    {
        Assert.Throws<ArgumentException>(() => CalculadoraSeguro.Calcular(valor));
    }
}
