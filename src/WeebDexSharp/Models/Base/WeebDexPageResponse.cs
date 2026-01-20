namespace WeebDexSharp.Models.Base;

/// <summary>
/// Represents a paginated response containing a collection of data items and pagination metadata from the WeebDex API.
/// </summary>
/// <typeparam name="T">The type of the data items contained in the response.</typeparam>
public class WeebDexPageResponse<T> : WeebDexResponse<T[]>
{
	/// <summary>
	/// The maximum number of items per page
	/// </summary>
	[JsonPropertyName("limit")]
	public int Limit { get; set; }

	/// <summary>
	/// The page of results returned
	/// </summary>
	[JsonPropertyName("page")]
	public int Page { get; set; }

	/// <summary>
	/// The total number of items available
	/// </summary>
	[JsonPropertyName("total")]
	public int Total { get; set; }

	/// <summary>
	/// The total number of pages available
	/// </summary>
	[JsonIgnore]
	public int TotalPages => (int)Math.Ceiling((double)Total / Limit);
}
