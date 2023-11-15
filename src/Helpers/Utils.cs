using Matsoft.ApiResults.CustomAttributes;
using FluentValidation.Results;
using System.ComponentModel;
using System.Net;

namespace Matsoft.ApiResults.Helpers
{
    /// <summary>
    /// Class <c>Utils</c> has internal utility methods to assist in creating api responses.
    /// </summary>
    public static class Utils
    {
        public static string Description(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
        }

        internal static HttpStatusCode? StatusCode(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (StatusCodeAttribute[])fieldInfo?.GetCustomAttributes(typeof(StatusCodeAttribute), false);

            return attributes?.Length > 0 ? attributes[0].Code : null;
        }

        internal static IEnumerable<string> CastToString(this IEnumerable<ValidationFailure> validationFailures)
            => validationFailures.Select(x => x.ToString()).Distinct();
    }
}