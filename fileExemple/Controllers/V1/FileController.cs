using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using fileExemple.Interfaces;
using fileExemple.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileExemple.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class FileController : BaseController
{

    private readonly IMediator _mediator;
    private readonly IUploadService _uploadService;

    public FileController(IMediator mediator,IUploadService uploadService)
    {
        _mediator = mediator;
        _uploadService = uploadService;
    }

    [HttpGet("export/{month}/{year}")]
    public async Task<IActionResult> ExportTemplate([Required] int month, int year)
    {
        // Esse método mostra como exportar um excel buscando dados do banco de dados
        // utilizando bibliotecas simples

        var request = new ImportFileRequest{ Month = month, Year = year};
        var response = await _mediator.Send(request).ConfigureAwait(false);

        return CreateResponse(response, HttpStatusCode.OK);
    }

    [HttpPost("upload")]
    [RequestFormLimits(MultipartBodyLengthLimit =1209715200)]
    [RequestSizeLimit(1209715200)]
    public async Task<IActionResult> Upload([Required]IFormFile file)
    {
        var result = await _uploadService.Upload(file);

        return CreateResponse(result, HttpStatusCode.OK);
    }
}
