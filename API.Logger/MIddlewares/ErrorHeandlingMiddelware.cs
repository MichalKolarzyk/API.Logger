using API.Logger.Exceptions;

namespace API.Logger.MIddlewares
{
    public class ErrorResponse
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
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
                    Title = ex.Title,
                    Message = ex.Message,
                    Code = ex.Code,
                });
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(new ErrorResponse()
                {
                    Title = "Something went wrong.",
                    Message = ex.Message,
                    Code = 500,
                });
            }
        }
    }
}
