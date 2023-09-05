using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OBiletCase.Services.Exceptions;
using OBiletCase.WebUI.Models;
using System.Diagnostics;
using System.Net;

namespace OBiletCase.WebUI.Filters
{
    /// <summary>
    /// This attribute class handles exceptions in the ASP.NET Core MVC application.
    /// It is designed to be used either at the controller level or at the action method level.
    /// It logs exceptions, sets HTTP status codes, and returns appropriate views or JSON responses.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HandleExceptionAttribute : TypeFilterAttribute
    {
        public HandleExceptionAttribute() : base(typeof(HandleExceptionPrivate))
        {
        }

        class HandleExceptionPrivate : ExceptionFilterAttribute
        {
            private readonly ILogger _logger;
            private readonly IWebHostEnvironment _environment;

            public HandleExceptionPrivate(ILoggerFactory logger, string category = "HandleExceptionAttribute")
            {
                _logger = logger.CreateLogger(category);
            }

            public override void OnException(ExceptionContext context)
            {
                // TODO : If it is in development mode by checking the environment, the server error detail can be printed.

                var exception = context.Exception;
                var message = "Beklenmeyen bir hata oluştu.";

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // If the exception is a business rule exception, the user should see this error message.
                if (context.Exception is BusinessRuleException)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    _logger.LogWarning(message);
                }
                else
                {
                    _logger.LogError(message);
                }

                var isAjaxCall = string.Equals(context.HttpContext.Request.Headers["X-Requested-With"],
                                               "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);

                // If the incoming request is an ajax call, the error message is set and the result is set to json.
                if (isAjaxCall)
                {
                    context.Result = new JsonResult(new
                    {
                        errorMessage = message
                    });
                }
                else
                {
                    context.Result = new ViewResult
                    {
                        ViewName = "Error",
                        ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                        {
                            Model = new ErrorViewModel
                            {
                                ErrorMessage = message
                            }
                        }
                    };
                }

                context.ExceptionHandled = true;
                context.Exception = null;
            }
        }
    }
}
