using API.Logger.Exceptions;

namespace API.Logger.MIddlewares
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }
    }

    public class ErrorHeandlingMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (DomainException ex)
            {
                context.Response.StatusCode = ex.Code;

                await context.Response.WriteAsJsonAsync(new ErrorResponse()
                {
                    Message = ex.Message,
                    Code = ex.Code,
                });
            }
        }
    }
}
