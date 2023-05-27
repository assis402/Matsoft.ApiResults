using System.Net;

namespace ApiResults.CustomAttributes
{
    /// <summary>
    /// Class <c>StatusCodeAttribute</c> defines, through an enum attribute, the HTTP status code of the API response.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class StatusCodeAttribute : Attribute
    {
        public HttpStatusCode Code { get; private set; }

        public StatusCodeAttribute(HttpStatusCode code) => Code = code;
    }
}