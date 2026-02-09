namespace Seguros.Infrastructure.Data;

public class SeguroEntity
{
    public Guid Id { get; set; }
    public decimal ValorVeiculo { get; set; }
    public string MarcaModeloVeiculo { get; set; } = string.Empty;
    public string NomeSegurado { get; set; } = string.Empty;
    public string CpfSegurado { get; set; } = string.Empty;
    public int IdadeSegurado { get; set; }
    public decimal ValorSeguro { get; set; }
}
