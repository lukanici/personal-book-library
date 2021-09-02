using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBookLibrary.Exceptions;

public class BookExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BookNotFoundException)
        {
            this.HandleException(context, StatusCodes.Status404NotFound);
            return;
        } else if (context.Exception is BookAlreadyExistsException)
        {
            this.HandleException(context, StatusCodes.Status400BadRequest);
            return;
        }
        context.ExceptionHandled = false;
    }

    private void HandleException(ExceptionContext context, int statusCode)
    {
        context.HttpContext.Response.StatusCode = statusCode;
        context.Result = new ObjectResult(new ApiResponse { Message = context.Exception.Message });
        context.ExceptionHandled = true;
    }
}
