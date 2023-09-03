using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using OBiletCase.Services.Exceptions;

namespace OBiletCase.WebUI.Filters
{
    public class HandleExceptionAttribute : TypeFilterAttribute
    {
        public HandleExceptionAttribute() : base(typeof(HandleExceptionPrivate))
        {
        }

        class HandleExceptionPrivate : ExceptionFilterAttribute
        {
            private readonly ILogger _logger;
            private readonly IWebHostEnvironment _env;
            private string _message;

            public HandleExceptionPrivate(ILoggerFactory logger,
                IWebHostEnvironment env, string category = "HandleExceptionAttribute", string message = "İşlem sırasında bir hata oluştu!")
            {
                _logger = logger.CreateLogger(category);

                _env = env;
                _message = message;
            }

            public override void OnException(ExceptionContext context)
            {
                if (!(context.Exception is BusinessRuleException))
                {
                    _logger.LogError(5001, context.Exception, _message);
                }

                if (context.Exception is BusinessRuleException)
                {
                    _logger.LogWarning(3, context.Exception, _message);
                    _message = $"{context.Exception.Message}";
                }
                else if (_env.IsDevelopment() || _env.IsStaging())
                {
                    _message += " Exception Message: " + context.Exception.Message;
                }

                context.Result = new ContentResult() { Content = $"alert('{_message}');" };

                context.ExceptionHandled = true;
                context.Exception = null;
            }
        }
    }
}
