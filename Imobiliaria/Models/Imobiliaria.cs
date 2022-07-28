namespace Imobiliaria.Models;

public class Imobiliaria
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public string? Foto { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}