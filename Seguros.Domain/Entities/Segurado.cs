namespace Seguros.Domain.Entities;

public class Segurado
{
    public string Nome { get; private set; } = string.Empty;
    public string Cpf { get; private set; } = string.Empty;
    public int Idade { get; private set; }

    public Segurado(string nome, string cpf, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do segurado é obrigatório.");

        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF do segurado é obrigatório.");

        if (idade <= 0)
            throw new ArgumentException("Idade do segurado deve ser maior que zero.");

        Nome = nome.Trim();
        Cpf = cpf.Trim();
        Idade = idade;
    }
}
