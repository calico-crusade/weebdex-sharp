namespace WeebDexSharp.Models;

/// <summary>
/// Represents a generic entity in WeebDex
/// </summary>
public class WdEntity
{
	/// <summary>
	/// The ID of the entity
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;


	/// <summary>
	/// The name of the entity
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
}

/// <summary>
/// The entity returned by paged requests
/// </summary>
public class WdPagedEntity : WdEntity
{
	/// <summary>
	/// The type of entity
	/// </summary>
	[JsonPropertyName("group")]
	public WdEntityType Group { get; set; }
}

/// <summary>
/// The different types of <see cref="WdPagedEntity"/>
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<WdEntityType>))]
public enum WdEntityType
{
	/// <summary>
	/// Unknown
	/// </summary>
	Content,
	/// <summary>
	/// Unknown
	/// </summary>
	Format,
	/// <summary>
	/// Entity is a manga genre
	/// </summary>
	Genre,
	/// <summary>
	/// Entity is a manga theme
	/// </summary>
	Theme,
	/// <summary>
	/// Entity is an author
	/// </summary>
	Author,
	/// <summary>
	/// Entity is a manga tag
	/// </summary>
	Tag
}
