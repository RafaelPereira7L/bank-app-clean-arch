using System.Net;
using Bank.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bank.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.ExceptionHandled = true;
        
        
        if (context.Exception is Exception)
        {
            context.Result = new JsonResult( new { Message = context.Exception.Message, Status = StatusCodes.Status500InternalServerError });
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return;
        }
        

        if (context.Exception is ArgumentException)
        {
            context.Result = new JsonResult( new { Message = "Invalid argument", Status = StatusCodes.Status400BadRequest });
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        if (context.Exception is AccountNotFoundException)
        {
            context.Result = new JsonResult( new { Message = "Account not found", Status = StatusCodes.Status404NotFound });
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }
        
        if (context.Exception is InsufficientBalanceException)
        {
            context.Result = new JsonResult( new { Message = "Insufficient balance", Status = StatusCodes.Status400BadRequest });
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}