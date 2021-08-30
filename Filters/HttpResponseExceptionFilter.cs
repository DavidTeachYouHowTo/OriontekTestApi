using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OriontekTest.Services.ErrorsMessageConfiguration.Exceptions;
using System.Net;

namespace OriontekTest.Api.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;
        public void OnActionExecuting(ActionExecutingContext context) { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(new { errors = exception.Errors })
                {
                    StatusCode = (int)exception.StatusCode,
                };
            }
            else if (!(context.Exception is null))
            {
                context.Result = new ObjectResult(new
                {
                    errorMessage = context.Exception.Message,
                    innerException = context.Exception.InnerException?.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                };
            }
            context.ExceptionHandled = true;
        }
    }
}
