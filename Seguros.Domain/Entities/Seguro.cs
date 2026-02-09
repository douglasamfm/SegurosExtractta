namespace Seguros.Domain.Entities;

public class Seguro
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Veiculo Veiculo { get; private set; }
    public Segurado Segurado { get; private set; }
    public decimal ValorSeguro { get; private set; }

    public Seguro(Veiculo veiculo, Segurado segurado, decimal valorSeguro)
    {
        Veiculo = veiculo ?? throw new ArgumentNullException(nameof(veiculo));
        Segurado = segurado ?? throw new ArgumentNullException(nameof(segurado));

        if (valorSeguro < 0)
            throw new ArgumentException("O valor do seguro não pode ser negativo.");

        ValorSeguro = valorSeguro;
    }

 
    public Seguro(Guid id, Veiculo veiculo, Segurado segurado, decimal valorSeguro)
        : this(veiculo, segurado, valorSeguro)
    {
        Id = id;
    }
}
