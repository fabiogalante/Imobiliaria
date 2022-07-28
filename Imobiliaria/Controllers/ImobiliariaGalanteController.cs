using Imobiliaria.Data;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Controllers;


[ApiController]
[Route("v1")]
public class ImobiliariaGalanteController : ControllerBase
{

    [HttpGet]
    [Route("imobiliarias")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var imobiliarias = await context
            .Imobiliarias
            .AsNoTracking()
            .ToListAsync();
        return Ok(imobiliarias);
    }

    [HttpGet]
    [Route("imobiliarias/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var imobiliaria = await context
            .Imobiliarias
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id == id);

        return imobiliaria != null ? Ok(imobiliaria) : NotFound();
    }

    [HttpPost("imobiliarias")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context,
        [FromBody] CriarImobiliariaViewModel imobiliariaViewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var imobiliaria = new Models.Imobiliaria
        {
            Descricao = imobiliariaViewModel.Descricao,
            Foto = imobiliariaViewModel.Foto,
            Titulo = imobiliariaViewModel.Titulo,
            Valor = imobiliariaViewModel.Valor
        };

        try
        {
            await context.Imobiliarias.AddAsync(imobiliaria);
            await context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500);
        }



        return Created($"v1/imobiliaria/{imobiliaria.Id}", imobiliaria);

    }


    [HttpPut("imobiliarias/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context,
        [FromBody] CriarImobiliariaViewModel imobiliariaViewModel, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var imobiliaria = await context
            .Imobiliarias
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (imobiliaria == null)
            return NotFound();

        try
        {
            imobiliaria.Descricao = imobiliariaViewModel.Descricao;
            imobiliaria.Foto = imobiliariaViewModel.Foto;
            imobiliaria.Titulo = imobiliariaViewModel.Titulo;
            imobiliaria.Valor = imobiliariaViewModel.Valor;

            context.Imobiliarias.Update(imobiliaria);
            await context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500);
        }

        return Ok();
    }


    [HttpDelete("imobiliarias/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {


        var imobiliaria = await context
            .Imobiliarias
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (imobiliaria == null)
            return NotFound();

        try
        {
            context.Imobiliarias.Remove(imobiliaria);
            await context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500);
        }

        return Ok();
    }

}