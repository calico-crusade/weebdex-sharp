namespace WeebDexSharp.Models.Base;

/// <summary>
/// Represents the metadata for the request
/// </summary>
public class RequestMetaData
{
	/// <summary>
	/// Indicates any rate limit information returned with the response
	/// </summary>
	public RateLimit? RateLimits { get; set; }

	/// <summary>
	/// The metadata related to the request being made
	/// </summary>
	public RequestData Request { get; set; } = new();

	/// <summary>
	/// The metadata realted to the response being made
	/// </summary>
	public ResponseData Response { get; set; } = new();

	/// <summary>
	/// How long the request took
	/// </summary>
	public TimeSpan Elapsed { get; set; }

	/// <summary>
	/// The data shared between the request and response
	/// </summary>
	public abstract class Data
	{
		/// <summary>
		/// The headers of the request/response
		/// </summary>
		public Dictionary<string, string[]> Headers { get; set; } = [];

		/// <summary>
		/// The body of the request/response
		/// </summary>
		public string? Body { get; set; }
	}

	/// <summary>
	/// Data related to the request being made
	/// </summary>
	public class RequestData : Data
	{
		/// <summary>
		/// The method of the request
		/// </summary>
		public HttpMethod Method { get; set; } = HttpMethod.Get;

		/// <summary>
		/// The URI of the request
		/// </summary>
		public string Uri { get; set; } = "https://weebdex.org/";
	}

	/// <summary>
	/// Data related to the response being received
	/// </summary>
	public class ResponseData : Data
	{
		/// <summary>
		/// The status code of the response or null if no response was received
		/// </summary>
		public HttpStatusCode? StatusCode { get; set; }

		/// <summary>
		/// The reason phrase of the response
		/// </summary>
		public string? ReasonPhrase { get; set; }

		/// <summary>
		/// The exception if one occurred during the request
		/// </summary>
		[JsonConverter(typeof(WeebDexExceptionParser))]
		public Exception? Exception { get; set; }

		/// <summary>
		/// How long it took for the server to respond
		/// </summary>
		public TimeSpan RequestElapsed { get; set; }

		/// <summary>
		/// How long it took to read the response
		/// </summary>
		public TimeSpan ReadElapsed { get; set; }

		/// <summary>
		/// Whether or not the request succeeded
		/// </summary>
		public bool Succeeded => Exception is null && StatusCode >= HttpStatusCode.OK && StatusCode < HttpStatusCode.MultipleChoices;
	}
}
