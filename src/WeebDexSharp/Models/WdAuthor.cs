namespace WeebDexSharp.Models;

/// <summary>
/// Represents an author in WeebDex
/// </summary>
public class WdAuthor : AuthorData
{
	/// <summary>
	/// The ID of the author
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// When the author was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	/// <summary>
	/// When the author was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }
}

/// <summary>
/// All of the data that makes up an author's information
/// </summary>
public class AuthorData
{
	/// <summary>
	/// The name of the author
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The author's profile description
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Whether or not the author's data is locked
	/// </summary>
	[JsonPropertyName("locked")]
	public bool? Locked { get; set; }

	/// <summary>
	/// The version of the author's data
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }
	
	/// <summary>
	/// The author's FanBox URL
	/// </summary>
	[JsonPropertyName("fanbox")]
	public string? FanBox { get; set; }

	/// <summary>
	/// The author's Fantia URL
	/// </summary>
	[JsonPropertyName("fantia")]
	public string? Fantia { get; set; }

	/// <summary>
	/// The author's Pixiv URL
	/// </summary>
	[JsonPropertyName("pixiv")]
	public string? Pixiv { get; set; }

	/// <summary>
	/// The author's Skeb URL
	/// </summary>
	[JsonPropertyName("skeb")]
	public string? Skeb { get; set; }

	/// <summary>
	/// The author's Twitter URL
	/// </summary>
	[JsonPropertyName("twitter")]
	public string? Twitter { get; set; }

	/// <summary>
	/// The author's YouTube URL
	/// </summary>
	[JsonPropertyName("youtube")]
	public string? YouTube { get; set; }

	/// <summary>
	/// The author's Website URL
	/// </summary>
	[JsonPropertyName("website")]
	public string? Website { get; set; }
}
