namespace WeebDexSharp.Models;

/// <summary>
/// Represents a cover image
/// </summary>
public class WdCover : WdImageBase
{
	/// <summary>
	/// The date and time the cover was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	/// <summary>
	/// The date and time the cover was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }

	/// <summary>
	/// The file extension
	/// </summary>
	[JsonPropertyName("ext")]
	public string Extension { get; set; } = string.Empty;

	/// <summary>
	/// The ID of the cover
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// The language code of the cover
	/// </summary>
	[JsonPropertyName("language")]
	public string Language { get; set; } = string.Empty;

	/// <summary>
	/// The description of the cover
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The version of the cover
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }

	/// <summary>
	/// The volume the cover belongs to
	/// </summary>
	[JsonPropertyName("volume")]
	public string? Volume { get; set; }

	/// <summary>
	/// The relationship data for the cover
	/// </summary>
	[JsonPropertyName("relationships")]
	public CoverRelationships Relationships { get; set; } = new();

	/// <summary>
	/// The data to create a cover
	/// </summary>
	public class Create
	{
		/// <summary>
		/// The description of the cover
		/// </summary>
		[JsonPropertyName("description")]
		public string? Description { get; set; }

		/// <summary>
		/// The language code of the cover
		/// </summary>
		[JsonPropertyName("language")]
		public string? Language { get; set; }

		/// <summary>
		/// Whether or not this cover is the main cover image
		/// </summary>
		[JsonPropertyName("main")]
		public bool? Main { get; set; }

		/// <summary>
		/// The version of the cover
		/// </summary>
		[JsonPropertyName("version")]
		public int Version { get; set; }

		/// <summary>
		/// The volume the cover belongs to
		/// </summary>
		[JsonPropertyName("volume")]
		public string? Volume { get; set; }
	}

	/// <summary>
	/// The relationships for the cover
	/// </summary>
	public class CoverRelationships
	{
		/// <summary>
		/// The user who uploaded the cover
		/// </summary>
		[JsonPropertyName("uploader")]
		public WdEntity Uploader { get; set; } = new();
	}
}
