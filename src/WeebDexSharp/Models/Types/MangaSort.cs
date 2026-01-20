namespace WeebDexSharp.Models.Types;

/// <summary>
/// The various sorting options for manga
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<MangaSort>))]
public enum MangaSort
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	CreatedAt,
	UpdatedAt,
	LastUploadedChapterAt,
	Relevance,
	Title,
	Year,
	Rating,
	Views,
	Follows,
	Chapters
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
