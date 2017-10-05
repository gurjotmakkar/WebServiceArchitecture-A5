﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Assignment5
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Add ByteFormatter to the pipeline
            config.Formatters.Add(new ServiceLayer.ByteFormatter());

            // Add HandleError to the pipeline
            config.Services.Replace(typeof(IExceptionHandler), new ServiceLayer.HandleError());

            // Handle HTTP OPTIONS requests
            config.MessageHandlers.Add(new ServiceLayer.HandleHttpOptions());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Root", id = RouteParameter.Optional }
            );
        }
    }
}
