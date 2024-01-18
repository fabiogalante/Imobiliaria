using Imobiliaria.Data;
using Imobiliaria.Models;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Imobiliaria.Controllers;

[ApiController]
[Route("v1")]
public class AnunciosController : ControllerBase
{
    [HttpGet]
    [Route("anuncios")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var imobiliarias = await context
            .Anuncios
            .AsNoTracking()
            .ToListAsync();
        return Ok(imobiliarias);
    }

    [HttpGet]
    [Route("anuncios/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var imobiliaria = await context
            .Anuncios
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id == id);

        return imobiliaria != null ? Ok(imobiliaria) : NotFound();
    }

    [HttpPost("anuncios")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context,
        [FromBody] CriarImobiliariaViewModel imobiliariaViewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var imobiliaria = new Anuncio
        {
            Descricao = imobiliariaViewModel.Descricao,
            Foto = imobiliariaViewModel.Foto,
            Titulo = imobiliariaViewModel.Titulo,
            Valor = imobiliariaViewModel.Valor
        };

        try
        {
            await context.Anuncios.AddAsync(imobiliaria);
            await context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500);
        }



        return Created($"v1/anuncios/{imobiliaria.Id}", imobiliaria);

    }


    [HttpPut("anuncios/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context,
        [FromBody] CriarImobiliariaViewModel imobiliariaViewModel, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var imobiliaria = await context
            .Anuncios
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (imobiliaria == null)
            return NotFound();

        try
        {
            imobiliaria.Descricao = imobiliariaViewModel.Descricao;
            imobiliaria.Foto = imobiliariaViewModel.Foto;
            imobiliaria.Titulo = imobiliariaViewModel.Titulo;
            imobiliaria.Valor = imobiliariaViewModel.Valor;

            context.Anuncios.Update(imobiliaria);
            await context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500);
        }

        return Ok();
    }


    [HttpDelete("anuncios/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var imobiliaria = await context
            .Anuncios
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (imobiliaria == null)
            return NotFound();

        try
        {
            context.Anuncios.Remove(imobiliaria);
            await context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500);
        }
        return Ok();
    }

}