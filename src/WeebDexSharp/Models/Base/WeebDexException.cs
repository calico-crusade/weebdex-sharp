namespace WeebDexSharp.Models.Base;

/// <summary>
/// Represents an exception thrown by WeebDexSharp
/// </summary>
/// <param name="_request">The request that spawned the exception</param>
public class WeebDexException(
	WeebDexResponse _request) : Exception("An error occurred while making a request", _request.MetaData.Response.Exception)
{
	/// <summary>
	/// The request that was made
	/// </summary>
	public WeebDexResponse Request => _request;

	/// <summary>
	/// The response code that was returned
	/// </summary>
	public HttpStatusCode Code => _request.MetaData.Response.StatusCode ?? HttpStatusCode.InternalServerError;
}
