namespace WeebDexSharp.Models;

/// <summary>
/// Represents an API client
/// </summary>
public class WdApiClient : WdEntity
{
	/// <summary>
	/// The date the client was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	/// <summary>
	/// The date the client was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }

	/// <summary>
	/// The version number of the client
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }

	/// <summary>
	/// The creation data for an API client
	/// </summary>
	public class Data
	{
		/// <summary>
		/// The name of the client to create
		/// </summary>
		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;
	}
}

/// <summary>
/// Represents a <see cref="WdApiClient"/> that also includes the secret key
/// </summary>
public class WdApiClientWithSecret : WdApiClient
{
	/// <summary>
	/// The API key for the client
	/// </summary>
	[JsonPropertyName("key")]
	public string Key { get; set; } = string.Empty;
}
