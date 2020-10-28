using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Server.Helper.Exeptions
{
    public class CustomExeptionBase:Exception
    {
        public CustomExeptionBase() :base()
        {
        }
        public CustomExeptionBase(string message) : base(message)
        {
        }
        public CustomExeptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }
        public virtual HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public virtual void Handle(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)this.StatusCode;
            //context.Result = new JsonResult(new
            //{
            //    error = new[] { context.Exception.Message }
            //});
        }

    }
}