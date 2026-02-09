using Microsoft.AspNetCore.Mvc;
using Seguros.Application.Contracts;
using Seguros.Application.UseCases;

namespace Seguros.Controllers;

[ApiController]
[Route("api/seguros")]
public class SegurosController : ControllerBase
{
    private readonly SeguroService _service;

    public SegurosController(SeguroService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<SeguroResponse>> Criar([FromBody] CriarSeguroRequest req, CancellationToken ct)
    {
        var criado = await _service.CriarAsync(req, ct);
        return CreatedAtAction(nameof(ObterPorId), new { id = criado.Id }, criado);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SeguroResponse>> ObterPorId([FromRoute] Guid id, CancellationToken ct)
    {
        var seguro = await _service.ObterPorIdAsync(id, ct);
        if (seguro is null) return NotFound();

        return Ok(seguro);
    }

    [HttpGet("relatorio/media")]
    public async Task<ActionResult<RelatorioMediaSegurosResponse>> ObterMedia(CancellationToken ct)
    {
        var relatorio = await _service.ObterMediaAsync(ct);
        return Ok(relatorio);
    }

    [HttpGet("relatorio/ListaTodos")]
    public async Task<ActionResult<List<SeguroResponse>>> Listar(CancellationToken ct)
    {
        return Ok(await _service.ListarAsync(ct));
    }

}
