using CakeForYou.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeForYou.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => ((int) serviceException.StatusCode,
                    serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "InternalServerError")
            };

            return Problem(statusCode: statusCode, detail: message);
        }
    }
}