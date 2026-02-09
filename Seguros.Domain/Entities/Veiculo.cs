namespace Seguros.Domain.Entities;

public class Veiculo
{
    public decimal Valor { get; private set; }
    public string MarcaModelo { get; private set; } = string.Empty;

    public Veiculo(decimal valor, string marcaModelo)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do veículo deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(marcaModelo))
            throw new ArgumentException("Marca/Modelo do veículo é obrigatório.");

        Valor = valor;
        MarcaModelo = marcaModelo.Trim();
    }
}
