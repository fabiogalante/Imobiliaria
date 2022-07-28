using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.ViewModels;

public class CriarImobiliariaViewModel
{
    [Required]
    public string? Titulo { get; set; }

    [Required]
    public string? Descricao { get; set; }
        
    [Required]
    public decimal Valor { get; set; }

    public string? Foto { get; set; }
}