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
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMessage = string.Empty;

            var exeptionType = actionExecutedContext.Exception.GetType();
            if (exeptionType == typeof(LoginExeption))
            {
                errorMessage = "Invalid credentials";
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                errorMessage = "Contact Admin";
                statusCode = HttpStatusCode.InternalServerError;
            }
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errorMessage),
                ReasonPhrase = "From filter"
            };

            actionExecutedContext.Response = response;
            base.OnException(actionExecutedContext);
        }
    }

}