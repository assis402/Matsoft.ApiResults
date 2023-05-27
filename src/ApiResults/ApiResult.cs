using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ApiResults
{
    public class ApiResult
    {
        /// <param name="success">Represents whether the API was successful or error.</param>
        /// <param name="message">Represents API response message (ex: "Order created with success.").</param>
        /// <param name="data">Represents API response data (ex: to return a oject in JSON).</param>
        /// <param name="statusCode">HTTP status code of API response (ex: 200 - OK).</param>
        public ApiResult(bool success, string message = null, dynamic data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = (int)statusCode;
        }

        /// <value>
        /// Property <c>Message</c> represents the API response principal message.
        /// </value>
        public bool Success { get; set; }

        /// <value>
        /// Property <c>Message</c> represents the API response principal message.
        /// </value>
        public int StatusCode { get; set; }

        /// <value>
        /// Property <c>Message</c> represents the API response principal message.
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <value>
        /// Property <c>Data</c> represents the data content of API response.
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }

        /// <summary>
        /// This method convert the <c>ApiResult</c> instance in a <c>ObjectResult</c>.
        /// </summary>
        public ObjectResult Convert()
            => new(this) { StatusCode = StatusCode };
    }
}