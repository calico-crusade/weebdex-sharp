namespace WeebDexSharp.Models.Types;

/// <summary>
/// The status of a manga
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<MangaStatus>))]
public enum MangaStatus
{
	/// <summary>
	/// The manga is ongoing
	/// </summary>
	Ongoing,
	/// <summary>
	/// The manga is completed
	/// </summary>
	Completed,
	/// <summary>
	/// The manga is on hiatus
	/// </summary>
	Hiatus,
	/// <summary>
	/// The manga is cancelled
	/// </summary>
	Cancelled
}
