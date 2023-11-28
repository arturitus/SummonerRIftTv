using System;
using System.Net;

namespace LeagueSpectator.RiotApi.Models
{
    public class RiotApiError(HttpStatusCode statusCode, string errorMessage, string functionName) : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = statusCode;
        public string ErrorMessage { get; set; } = errorMessage;
        public string FunctionName { get; set; } = functionName;
    }
}