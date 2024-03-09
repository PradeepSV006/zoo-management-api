using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Zoo.API.Filters
{
    public class CommonExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            LogException(context.Exception);
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        private void LogException(Exception exception)
        {
            Console.WriteLine($"Exception logged: {exception.Message}");
        }
    }
}
