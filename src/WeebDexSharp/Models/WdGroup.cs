namespace WeebDexSharp.Models;

/// <summary>
/// Represents a scanlation group in weebdex
/// </summary>
public class WdGroup : WdEntity
{
	/// <summary>
	/// The date and time the group was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	/// <summary>
	/// The date and time the group was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }

	/// <summary>
	/// The description of the group
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The version of the group information
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }

	/// <summary>
	/// The group's discord link
	/// </summary>
	[JsonPropertyName("discord")]
	public string? Discord { get; set; }

	/// <summary>
	/// The group's twitter link
	/// </summary>
	[JsonPropertyName("twitter")]
	public string? Twitter { get; set; }

	/// <summary>
	/// The group's website link
	/// </summary>
	[JsonPropertyName("website")]
	public string? Website { get; set; }

	/// <summary>
	/// The group's Manga Updates link
	/// </summary>
	[JsonPropertyName("mangaupdates")]
	public string? MangaUpdates { get; set; }

	/// <summary>
	/// The email address to use to contact the group
	/// </summary>
	[JsonPropertyName("content_email")]
	public string? Email { get; set; }
	
	/// <summary>
	/// Whether or not the group is inactive
	/// </summary>
	[JsonPropertyName("inactive")]
	public bool Inactive { get; set; }

	/// <summary>
	/// Whether or not the group is locked
	/// </summary>
	[JsonPropertyName("locked")]
	public bool Locked { get; set; }

	/// <summary>
	/// The relationships of the group
	/// </summary>
	[JsonPropertyName("relationships")]
	public GroupRelationships Relationships { get; set; } = new();

	/// <summary>
	/// Represents all of the information related to the group
	/// </summary>
	public class GroupRelationships
	{
		/// <summary>
		/// All of the members of the group
		/// </summary>
		[JsonPropertyName("members")]
		public Member[] Members { get; set; } = [];

		/// <summary>
		/// The information regarding comments attached to the group
		/// </summary>
		[JsonPropertyName("thread")]
		public WdThread Thread { get; set; } = new();
	}

	/// <summary>
	/// Represents a group member
	/// </summary>
	public class Member : WdEntity
	{
		/// <summary>
		/// The user's avatar URL
		/// </summary>
		[JsonPropertyName("avatar_url")]
		public string? AvatarUrl { get; set; }

		/// <summary>
		/// The description of the user
		/// </summary>
		[JsonPropertyName("description")]
		public string? Description { get; set; }

		/// <summary>
		/// The user's discord link
		/// </summary>
		[JsonPropertyName("discord")]
		public string? Discord { get; set; }

		/// <summary>
		/// The user's twitter link
		/// </summary>
		[JsonPropertyName("twitter")]
		public string? Twitter { get; set; }

		/// <summary>
		/// The user's website link
		/// </summary>
		[JsonPropertyName("website")]
		public string? Website { get; set; }

		/// <summary>
		/// The version of the user information
		/// </summary>
		[JsonPropertyName("version")]
		public int Version { get; set; }

		/// <summary>
		/// The user's roles within the group
		/// </summary>
		[JsonPropertyName("roles")]
		public string[] Roles { get; set; } = [];

		/// <summary>
		/// Whether or not the user is the leader of the group
		/// </summary>
		[JsonPropertyName("is_leader")]
		public bool IsLeader { get; set; }

		/// <summary>
		/// Whether or not the user is an officer of the group
		/// </summary>
		[JsonPropertyName("is_officer")]
		public bool IsOfficer { get; set; }
	}

	/// <summary>
	/// Creates a group
	/// </summary>
	public class Create
	{
		/// <summary>
		/// The name of the group
		/// </summary>
		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// The description of the group
		/// </summary>
		[JsonPropertyName("description")]
		public string? Description { get; set; }

		/// <summary>
		/// The group's discord link
		/// </summary>
		[JsonPropertyName("discord")]
		public string? Discord { get; set; }

		/// <summary>
		/// The group's twitter link
		/// </summary>
		[JsonPropertyName("twitter")]
		public string? Twitter { get; set; }

		/// <summary>
		/// The group's website link
		/// </summary>
		[JsonPropertyName("website")]
		public string? Website { get; set; }

		/// <summary>
		/// The group's Manga Updates link
		/// </summary>
		[JsonPropertyName("mangaupdates")]
		public string? MangaUpdates { get; set; }

		/// <summary>
		/// The email address to use to contact the group
		/// </summary>
		[JsonPropertyName("content_email")]
		public string? Email { get; set; }
	}

	/// <summary>
	/// Represents a request to update a group
	/// </summary>
	public class Update
	{
		/// <summary>
		/// The ID of the leader of the group
		/// </summary>
		[JsonPropertyName("leader")]
		public string? Leader { get; set; }

		/// <summary>
		/// The members of the group (less than 51)
		/// </summary>
		[JsonPropertyName("members")]
		public string[]? Members { get; set; }

		/// <summary>
		/// The officers of the group (less than 4)
		/// </summary>
		[JsonPropertyName("officers")]
		public string[]? Officers { get; set; }

		/// <summary>
		/// Whether or not the group is locked
		/// </summary>
		[JsonPropertyName("locked")]
		public bool? Locked { get; set; }

		/// <summary>
		/// Whether or not the group is inactive
		/// </summary>
		[JsonPropertyName("inactive")]
		public bool? Inactive { get; set; }

		/// <summary>
		/// The name of the group
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		/// <summary>
		/// The description of the group
		/// </summary>
		[JsonPropertyName("description")]
		public string? Description { get; set; }

		/// <summary>
		/// The group's discord link
		/// </summary>
		[JsonPropertyName("discord")]
		public string? Discord { get; set; }

		/// <summary>
		/// The group's twitter link
		/// </summary>
		[JsonPropertyName("twitter")]
		public string? Twitter { get; set; }

		/// <summary>
		/// The group's website link
		/// </summary>
		[JsonPropertyName("website")]
		public string? Website { get; set; }

		/// <summary>
		/// The group's Manga Updates link
		/// </summary>
		[JsonPropertyName("mangaupdates")]
		public string? MangaUpdates { get; set; }

		/// <summary>
		/// The email address to use to contact the group
		/// </summary>
		[JsonPropertyName("content_email")]
		public string? Email { get; set; }

		/// <summary>
		/// The version of the group information
		/// </summary>
		[JsonPropertyName("version")]
		public int Version { get; set; }
	}
}

/// <summary>
/// A paginated list of groups
/// </summary>
public class WdGroupList : WeebDexPageResponse<WdGroup> { }