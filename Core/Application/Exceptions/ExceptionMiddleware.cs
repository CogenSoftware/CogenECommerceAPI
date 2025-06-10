using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace Core.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ExceptionModel
                {
                    statusCode = StatusCodes.Status400BadRequest,
                    errors = ((ValidationException)exception).Errors.Select(e => e.ErrorMessage)
                }.ToString());
            }

            List<string> errors = new()
            {
                exception.Message,
                exception.InnerException != null ? exception.InnerException.ToString() : string.Empty
            };

            return context.Response.WriteAsync(new ExceptionModel
            {
                statusCode = statusCode,
                errors = errors
            }.ToString());
        }

        private static int GetStatusCode(Exception exception) => exception switch
        {
            BadRequestException _ => StatusCodes.Status400BadRequest,
            NotFoundException _ => StatusCodes.Status404NotFound,
            ValidationException _ => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}