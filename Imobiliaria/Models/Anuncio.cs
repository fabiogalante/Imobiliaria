namespace Imobiliaria.Models;


//https://www.c-sharpcorner.com/blogs/nonnullable-property-must-contain-a-nonnull-value
//https://docs.microsoft.com/en-us/answers/questions/829616/non-nullable-property-39model39-must-contain-a-non.html

public class Anuncio
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public string? Foto { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}