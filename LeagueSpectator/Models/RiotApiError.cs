using System;
using System.Net;

namespace LeagueSpectator.Models
{
    public class RiotApiError : Exception
    {
        public RiotApiError(HttpStatusCode statusCode, string? errorMessage, string? functionName)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            FunctionName = functionName;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string FunctionName { get; set; }
    }
}