using Exceptions;
using Microsoft.AspNetCore.Diagnostics;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var (statusCode, message) = contextFeature.Error switch
                    {
                        ItemNotFoundException ex => (StatusCodes.Status404NotFound, ex.Message),
                        _ => (StatusCodes.Status500InternalServerError, "Internal Server Error."),
                    };
                    context.Response.StatusCode = statusCode;
                    context.Response.ContentType = "application/json";

                    logger.LogError($"Something went wrong: {contextFeature.Error}");

                    await context.Response.WriteAsync(
                        new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = message,
                        }.ToString()
                    );
                }
            });
        });
    }
}
