namespace WeebDexSharp.Models.Types;

/// <summary>
/// The state of a weeb dex entity
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<PublicationState>))]
public enum PublicationState
{
	/// <summary>
	/// Represents an unknown or unspecified value.
	/// </summary>
	Unknown,
	/// <summary>
	/// The entity hasn't been submitted yet
	/// </summary>
	Draft,
	/// <summary>
	/// The entity has been submitted for review
	/// </summary>
	Submitted,
	/// <summary>
	/// The entity has been published and is visible to all
	/// </summary>
	Published,
	/// <summary>
	/// The entity was rejected during review
	/// </summary>
	Rejected
}
