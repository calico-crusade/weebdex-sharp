namespace WeebDexSharp.Models;

/// <summary>
/// The group's stats
/// </summary>
public class WdGroupRating
{
	/// <summary>
	/// The number of chapters the group have published
	/// </summary>
	[JsonPropertyName("chapters")]
	public int Chapters { get; set; }

	/// <summary>
	/// The number of followers the group has
	/// </summary>
	[JsonPropertyName("followers")]
	public int Followers { get; set; }

	/// <summary>
	/// The number of comments the group has
	/// </summary>
	[JsonPropertyName("replies")]
	public int Replies { get; set; }
}
