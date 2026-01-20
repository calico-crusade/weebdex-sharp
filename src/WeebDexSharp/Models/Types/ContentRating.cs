namespace WeebDexSharp.Models.Types;

/// <summary>
/// The content rating of a manga
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<ContentRating>))]
public enum ContentRating
{
	/// <summary>
	/// The chapter is safe for all audiences
	/// </summary>
	Safe,
	/// <summary>
	/// The chapter contains some suggestive themes
	/// </summary>
	Suggestive,
	/// <summary>
	/// The chapter contains censored adult content
	/// </summary>
	Erotica,
	/// <summary>
	/// The chapter contains explicit adult content
	/// </summary>
	Pornographic
}
