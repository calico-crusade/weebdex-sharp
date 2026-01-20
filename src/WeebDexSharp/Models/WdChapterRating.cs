namespace WeebDexSharp.Models;

/// <summary>
/// The chapter's stats
/// </summary>
public class WdChapterRating
{
	/// <summary>
	/// The number of people who have viewed the chapter
	/// </summary>
	[JsonPropertyName("views")]
	public int Views { get; set; }

	/// <summary>
	/// The number of unique views the chapter has
	/// </summary>
	[JsonPropertyName("unique_views")]
	public int UniqueViews { get; set; }

	/// <summary>
	/// The number of comments on the chapter
	/// </summary>
	[JsonPropertyName("replies")]
	public int Replies { get; set; }

	/// <summary>
	/// The number of upvotes on the chapter
	/// </summary>
	[JsonPropertyName("up")]
	public int Up { get; set; }
}
