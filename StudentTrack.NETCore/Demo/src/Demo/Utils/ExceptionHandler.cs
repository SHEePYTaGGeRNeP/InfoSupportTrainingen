using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Demo.Utils
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var obj = new
            {
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new ContentResult()
            {
                StatusCode = 500,
                ContentType = "text/plain",
                Content = JsonConvert.SerializeObject(obj)
            };
        }
    }
}
