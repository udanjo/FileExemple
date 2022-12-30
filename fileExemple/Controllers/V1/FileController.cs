using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using fileExemple.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fileExemple.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{

    private readonly IMediator _mediator;

    public FileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("export/{month}/{year}")]
    public async Task<IActionResult> ExportTemplate([Required] int month, int year)
    {
        var request = new ImportFileRequest{ Month = month, Year = year};
        var result = await _mediator.Send(request);

        if(result is null)
            return BadRequest();
        
        return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("cliente_{0}_{1}.xlsx", month, year));
    }
}
