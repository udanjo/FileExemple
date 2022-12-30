using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using fileExemple.Enums;
using fileExemple.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace fileExemple.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase    
    {
        protected IActionResult CreateResponse(HandlerResponse response, HttpStatusCode successStatusCode)
        => response.Type switch
        {
            ResponseType.Success => SuccessResponse(successStatusCode, response.Uri, response.Data),
            ResponseType.EntityValidationFail => BadRequest(response.Messages),
            ResponseType.BusinessValidationFail => UnprocessableEntity(response.Messages),
            ResponseType.File => File(response.Data, response.ContentType, response.FileDownloadName),
            _ => StatusCode(500, response.Messages)
        };

        protected IActionResult SuccessResponse(HttpStatusCode successStatusCode, string uri, dynamic data)
        => successStatusCode switch
        {
            HttpStatusCode.OK => data != null ? Ok(data) : Ok(),
            HttpStatusCode.Created => Created(uri, data),
            _ => NoContent()
        };
    }
}