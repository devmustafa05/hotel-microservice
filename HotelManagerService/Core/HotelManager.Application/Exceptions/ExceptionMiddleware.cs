using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using Serilog;



namespace HotelManager.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {   
            try
            {
                await next(httpContext);
            }
            catch (Exception exception)
            {

                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(s => s.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
            }

            HandleExceptionSeriLogAsync(httpContext, exception);

            List<string> errors = new()
            {
                $"Error Message: {exception.Message}"
                // $"Error Description: {exception.InnerException?.ToString()}"
            };

            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());
        }

        private static void HandleExceptionSeriLogAsync(HttpContext httpContext, Exception exception)
        {
            Log.Error("This is a test log for Elasticsearch. HTTP Request: {RequestPath}, HTTP Method: {RequestMethod}, Exception: {ExceptionMessage}, InnerException: {InnerException}, StackTrace: {StackTrace}",
                   httpContext.Request.Path, 
                   httpContext.Request.Method,
                   exception.Message, 
                   exception.InnerException, 
                   exception.StackTrace);
        }
        private static int GetStatusCode(Exception exception) =>
           exception switch
           {
               BadRequestException => StatusCodes.Status400BadRequest,
              // NotFoundException => StatusCodes.Status400BadRequest,
               NotFoundException => StatusCodes.Status404NotFound,
               ValidationException => StatusCodes.Status422UnprocessableEntity,
               _ => StatusCodes.Status500InternalServerError
           };
    }
}

