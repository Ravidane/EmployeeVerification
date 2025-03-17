namespace EmployeeVerification.Server.Middleware
{
    public class ExceptionHandler
        (RequestDelegate requestDelegate, ILogger<ExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Application Internal Error: {Message}", ex.Message);
                context.Response.StatusCode = 500;
            }
        }
    }
}
