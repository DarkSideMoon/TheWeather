﻿using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using TheWeather.Model.Common;
using TheWeather.Model.Exceptions;

namespace TheWeather.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private static readonly string InternalServerErrorMessage = "Internal Server Error";
        private static readonly string CityNotFoundErrorMessage = "City not found";

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(CityNotFoundException cityNotFoundException)
            {
                await HandleExceptionAsync(httpContext, cityNotFoundException, CityNotFoundErrorMessage,
                    StatusCodes.Status404NotFound)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, InternalServerErrorMessage,
                    StatusCodes.Status500InternalServerError)
                    .ConfigureAwait(false);
            }
        }

        protected static Task HandleExceptionAsync(HttpContext context, Exception exception, string message, int statusCode)
        {
            Log.Warning(exception, message);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            var errorResponse = CreateErrorResponse(context, message);
            var errorResponseJson = JsonConvert.SerializeObject(errorResponse,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return context.Response.WriteAsync(errorResponseJson);
        }

        protected static ErrorResponse CreateErrorResponse(HttpContext context, string message)
        {
            return new ErrorResponse(context.Response.StatusCode.ToString(), message);
        }
    }
}
