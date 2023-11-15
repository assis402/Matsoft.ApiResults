using Matsoft.ApiResults.Helpers;
using FluentValidation.Results;
using System.Net;

namespace Matsoft.ApiResults;

/// <summary>
/// Class <c>Result</c> models <c>ApiResult</c> objects for success and error scenario.
/// </summary>
public static class Result
{
    /// <summary>
    /// This method return a success ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": true,
    ///     "statusCode": 200,
    ///     "message": "Success Message",
    ///     "data": {
    ///         "id": "685a7c32-ebf6-4935-8ab0-d31b88276d4f",
    ///         "name": "First"
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="responseMessage">API response message (ex: "Order created with success.").</param>
    /// <param name="responseData">API response data.</param>
    /// <param name="statusCode">HTTP status code of API response.</param>
    public static ApiResult Success(string responseMessage, dynamic responseData = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(
                success: true,
                message: responseMessage,
                data: responseData,
                statusCode: statusCode
            );

    /// <summary>
    /// This method return a success ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": true,
    ///     "statusCode": 200,
    ///     "message": "Success Message",
    ///     "data": {
    ///         "id": "685a7c32-ebf6-4935-8ab0-d31b88276d4f",
    ///         "name": "First"
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="enumMessage">API response message by enum description.</param>
    /// <param name="responseData">API response data.</param>
    public static ApiResult Success(Enum enumMessage, dynamic responseData = null)
        => new(
                success: true,
                message: enumMessage.Description(),
                data: responseData,
                statusCode: enumMessage.StatusCode() ?? HttpStatusCode.OK
            );

    /// <summary>
    /// This method return a success ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": true,
    ///     "statusCode": 200,
    ///     "data": {
    ///         "id": "685a7c32-ebf6-4935-8ab0-d31b88276d4f",
    ///         "name": "First"
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="responseData">API response data.</param>
    /// <param name="statusCode">HTTP status code of API response.</param>
    public static ApiResult Success(dynamic responseData, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(
                success: true,
                data: responseData,
                statusCode: statusCode
            );

    /// <summary>
    /// This method return a error ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": false,
    ///     "statusCode": 400,
    ///     "message": "Error Message"
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="responseMessage">Represents API response message (ex: "Order created with success.").</param>
    /// <param name="statusCode">HTTP status code of API response.</param>
    public static ApiResult Error(string responseMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(
                success: false,
                message: responseMessage,
                statusCode: statusCode
            );

    /// <summary>
    /// This method return a error ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": false,
    ///     "statusCode": 400
    ///     "message": "Error Message"
    ///     "data": [
    ///         "Invalid data",
    ///         "Invalid param",
    ///         "Invalid input"
    ///     ]
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="responseMessage">API response message (ex: "Order created with success.").</param>
    /// <param name="errors">List of errors by a ValidationFailure list (FluentValidation).</param>
    /// <param name="statusCode">HTTP status code of API response.</param>
    public static ApiResult Error(string responseMessage, IEnumerable<ValidationFailure> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(
                success: false,
                message: responseMessage,
                data: errors.CastToString(),
                statusCode: statusCode
            );

    /// <summary>
    /// This method return a error ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": false,
    ///     "statusCode": 400
    ///     "message": "Error Message"
    ///     "data": [
    ///         "Invalid data",
    ///         "Invalid param",
    ///         "Invalid input"
    ///     ]
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="enumMessage">API response message by enum description.</param>
    /// <param name="errors">List of errors by a ValidationFailure list (FluentValidation).</param>
    public static ApiResult Error(Enum enumMessage, IEnumerable<ValidationFailure> errors)
        => new(
                success: false,
                message: enumMessage.Description(),
                data: errors.CastToString(),
                statusCode: enumMessage.StatusCode() ?? HttpStatusCode.BadRequest
            );

    /// <summary>
    /// This method return a error ApiResult
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": false,
    ///     "statusCode": 400
    ///     "message": "Error Message"
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="enumMessage">API response message by enum description.</param>
    public static ApiResult Error(Enum enumMessage)
        => new(
                success: false,
                message: enumMessage.Description(),
                statusCode: enumMessage.StatusCode() ?? HttpStatusCode.BadRequest
            );

    /// <summary>
    /// This method return a error ApiResult with Exception details
    /// <example>
    /// <code>
    /// For example:
    /// {
    ///     "success": false,
    ///     "statusCode": 400
    ///     "message": "Error Message"
    ///     "data": "Exception error message.."
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="enumMessage">API response message by enum description.</param>
    /// <param name="exception">API exception.</param>gi
    public static ApiResult Error(Enum enumMessage, Exception exception)
        => new(
                success: false,
                message: enumMessage.Description(),
                statusCode: enumMessage.StatusCode() ?? HttpStatusCode.BadRequest,
                data: new ExceptionData(exception)
            );
}