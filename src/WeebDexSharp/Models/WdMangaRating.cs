namespace WeebDexSharp.Models;


/// <summary>
/// Reprsents stats related to the manga
/// </summary>
public class WdMangaRating
{
	/// <summary>
	/// The number of people who have followed the manga
	/// </summary>
	[JsonPropertyName("follows")]
	public int Follows { get; set; }

	/// <summary>
	/// The number of people who have viewed the manga
	/// </summary>
	[JsonPropertyName("views")]
	public int Views { get; set; }

	/// <summary>
	/// The number of people who have sent comments in the manga's thread
	/// </summary>
	[JsonPropertyName("replies")]
	public int Replies { get; set; }

	/// <summary>
	/// The rating for the manga
	/// </summary>
	[JsonPropertyName("rating")]
	public WdRating Rating { get; set; } = new();
}
