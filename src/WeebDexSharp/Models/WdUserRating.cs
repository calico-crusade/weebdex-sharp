namespace WeebDexSharp.Models;

/// <summary>
/// Represents a user rating
/// </summary>
public class WdUserRating
{
	/// <summary>
	/// The number of chapters the user has uploaded
	/// </summary>
	[JsonPropertyName("chapters")]
	public int Chapters { get; set; }

	/// <summary>
	/// The number of groups the user has followed
	/// </summary>
	[JsonPropertyName("followed_groups")]
	public int FollowedGroups { get; set; }

	/// <summary>
	/// The number of users the user has followed
	/// </summary>
	[JsonPropertyName("followed_users")]
	public int FollowedUsers { get; set; }

	/// <summary>
	/// The number of people following the user
	/// </summary>
	[JsonPropertyName("followers")]
	public int Followers { get; set; }

	/// <summary>
	/// The number of manga in the user's library
	/// </summary>
	[JsonPropertyName("library")]
	public int Library { get; set; }

	/// <summary>
	/// The number of thread messages the user has sent
	/// </summary>
	[JsonPropertyName("replies")]
	public int Replies { get; set; }
}
