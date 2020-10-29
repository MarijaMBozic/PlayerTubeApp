using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Server.Helper.Exeptions.UserExeption;

namespace Server.Helper.Exeptions
{
    public class CustomExeptionFilter : ExceptionFilterAttribute
    {
        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{
        //     HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        //    string errorMessage = string.Empty;

        //    var exeptionType = actionExecutedContext.Exception.GetType();
        //    if (exeptionType == typeof(LoginExeption))
        //    {
        //        errorMessage = "Invalid credentials GLOBAL EXEPTION";
        //        statusCode = HttpStatusCode.NotFound;
        //    }
        //    else if (exeptionType == typeof(NullReferenceException))
        //    {
        //        errorMessage = "GLOBAL EXEPTION";
        //        statusCode = HttpStatusCode.NotFound;
        //    }
        //    else
        //    {
        //        errorMessage = "Contact ASdmin";
        //        statusCode = HttpStatusCode.InternalServerError;
        //    }
        //    var response = new HttpResponseMessage(statusCode)
        //    {
        //        Content = new StringContent(errorMessage),
        //        ReasonPhrase = "From filter"
        //    };

        //    actionExecutedContext.Response = response;
        //    base.OnException(actionExecutedContext);
        //}


            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                string exceptionMessage = string.Empty;
                if (actionExecutedContext.Exception.InnerException == null)
                {
                    exceptionMessage = actionExecutedContext.Exception.Message;
                }
                else
                {
                    exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
                }
                //We can log this exception message to the file or database.  
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("n unhandled exception was thrown by service."),  
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
                };
                actionExecutedContext.Response = response;
            }        
    }

}