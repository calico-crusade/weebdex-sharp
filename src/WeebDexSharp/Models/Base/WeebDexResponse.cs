namespace WeebDexSharp.Models.Base;

/// <summary>
/// Represents a response that was returned from the WeebDex API
/// </summary>
public class WeebDexResponse
{
	/// <summary>
	/// The metadata for the request
	/// </summary>
	[JsonIgnore]
	public RequestMetaData MetaData { get; internal set; } = new();

	/// <summary>
	/// Whether or not the request succeeded
	/// </summary>
	[JsonIgnore]
	public bool Succeeded => MetaData is not null && MetaData.Response.Succeeded;
}

/// <summary>
/// Represents a response that contains a strongly typed data payload from a WeebDex operation.
/// </summary>
/// <typeparam name="T">The type of the data payload included in the response.</typeparam>
public class WeebDexResponse<T> : WeebDexResponse
{
	/// <summary>
	/// The type of data being returned
	/// </summary>
	[JsonPropertyName("data")]
	public T Data { get; set; } = default!;
}