using System.Text.Json;
using FluentValidation;
using TWJobs.Api.Common.Dtos;
using TWJobs.Core.Exceptions;

namespace TWJobs.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ModelNotFoundException ex)
        {
            await handleModelNotFoundExceptionAsync(context, ex);
        }
        catch (ValidationException ex)
        {
            await handleValidationExceptionAsync(context, ex);
        }
    }

    private Task handleValidationExceptionAsync(HttpContext context, ValidationException ex)
    {
        var body = new ValidationErrorResponse
        {
            Status = 404,
            Error = "Bad Request",
            Cause = ex.GetType().Name,
            Message = "Validation Error",
            Timestamp = DateTime.UtcNow,
            Errors = ex.Errors.GroupBy(vf => vf.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage).ToArray())
        };

        context.Response.StatusCode = 400;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }

    private Task handleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException ex)
    {
        var body = new ErrorResponse
        {
            Status = 404,
            Error = "Not Found",
            Cause = ex.GetType().Name,
            Message = ex.Message,
            Timestamp = DateTime.UtcNow
        };

        context.Response.StatusCode = 404;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }
}