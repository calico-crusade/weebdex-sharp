namespace WeebDexSharp.Models;

/// <summary>
/// Represents a manga
/// </summary>
public class WdManga : WdMangaBase
{
	/// <summary>
	/// The alternate titles for the manga in various languages
	/// </summary>
	[JsonPropertyName("alt_titles")]
	public Dictionary<string, string[]> AltTitles { get; set; } = [];

	/// <summary>
	/// The description of the manga
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The version of the manga
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }

	/// <summary>
	/// The publication state of the manga
	/// </summary>
	[JsonPropertyName("state")]
	public PublicationState State { get; set; }

	/// <summary>
	/// The related data for this manga
	/// </summary>
	[JsonPropertyName("relationships")]
	public MangaRelationships Relationships { get; set; } = new();

	/// <summary>
	/// The URL to the cover of the manga
	/// </summary>
	[JsonIgnore]
	public string CoverImageUrl => $"https://weebdex.org/covers/{Id}/{Relationships.Cover.Id}.{Relationships.Cover.Extension.Trim('.')}";

	/// <summary>
	/// The relationships for the manga
	/// </summary>
	public class MangaRelationships
	{
		/// <summary>
		/// The cover for the manga
		/// </summary>
		[JsonPropertyName("cover")]
		public CoverImage Cover { get; set; } = new();

		/// <summary>
		/// The authors of the manga
		/// </summary>
		[JsonPropertyName("authors")]
		public WdPagedEntity[] Authors { get; set; } = [];

		/// <summary>
		/// The artists of the manga
		/// </summary>
		[JsonPropertyName("artists")]
		public WdPagedEntity[] Artists { get; set; } = [];

		/// <summary>
		/// All of the language codes for which this manga has been translated
		/// </summary>
		[JsonPropertyName("available_languages")]
		public string[] AvailableLanguages { get; set; } = [];

		/// <summary>
		/// All of the groups that have translated chapters for this manga
		/// </summary>
		[JsonPropertyName("available_groups")]
		public WdEntity[] AvailableGroups { get; set; } = [];

		/// <summary>
		/// All of the links to external sites for this manga
		/// </summary>
		[JsonPropertyName("links")]
		public Dictionary<string, string> Links { get; set; } = [];

		/// <summary>
		/// The stats related to the manga
		/// </summary>
		[JsonPropertyName("stats")]
		public WdMangaRating Stats { get; set; } = new();

		/// <summary>
		/// The person who submitted the manga
		/// </summary>
		[JsonPropertyName("submitter")]
		public WdPagedEntity Submitter { get; set; } = new();

		/// <summary>
		/// The tags of the manga
		/// </summary>
		[JsonPropertyName("tags")]
		public WdPagedEntity[] Tags { get; set; } = [];

		/// <summary>
		/// The information about the manga's comment thread
		/// </summary>
		[JsonPropertyName("thread")]
		public WdThread Thread { get; set; } = new();

		/// <summary>
		/// All of the related manga
		/// </summary>
		[JsonPropertyName("relations")]
		public RelatedManga[] Relations { get; set; } = [];
	}

	/// <summary>
	/// Represents a cover image
	/// </summary>
	public class CoverImage : WdImageBase
	{
		/// <summary>
		/// The ID of the cover image
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// The extension for the cover image file
		/// </summary>
		[JsonPropertyName("ext")]
		public string Extension { get; set; } = string.Empty;
	}

	/// <summary>
	/// Represents a manga that is related to another manga, including the type of relationship between them.
	/// </summary>
	public class RelatedManga : WdMangaPartial
	{
		/// <summary>
		/// The type of relationship between the two manga
		/// </summary>
		[JsonPropertyName("type")]
		public RelationType Type { get; set; }
	}

	/// <summary>
	/// The relationship between two manga
	/// </summary>
	[JsonConverter(typeof(WeebDexEnumParser<RelationType>))]
	public enum RelationType
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		main_story,
		side_story,
		prequel,
		sequel,
		adapted_from,
		spin_off,
		based_on,
		doujinshi,
		monochrome,
		colored,
		preserialization,
		serialization,
		alternate_story,
		alternate_version,
		same_franchise,
		shared_universe
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// Represents the POST body for creating a manga relationship
	/// </summary>
	public class CreateRelation
	{
		/// <summary>
		/// The ID of the manga being related to
		/// </summary>
		[JsonPropertyName("related_id")]
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// The type of relationship
		/// </summary>
		[JsonPropertyName("type")]
		public RelationType Type { get; set; }
	}

	/// <summary>
	/// Represents the DELETE body for deleting a manga relationship
	/// </summary>
	public class DeleteRelation
	{
		/// <summary>
		/// The ID of the manga being related to
		/// </summary>
		[JsonPropertyName("related_id")]
		public string Id { get; set; } = string.Empty;
	}
}

/// <summary>
/// The partial data for <see cref="WdManga"/>
/// </summary>
public class WdMangaPartial : WdMangaBase
{
	/// <summary>
	/// The related data for this manga
	/// </summary>
	[JsonPropertyName("relationships")]
	public MangaRelationships Relationships { get; set; } = new();

	/// <summary>
	/// The URL to the cover of the manga
	/// </summary>
	[JsonIgnore]
	public string CoverImageUrl => $"https://weebdex.org/covers/{Id}/{Relationships.Cover.Id}.{Relationships.Cover.Extension.Trim('.')}";

	/// <summary>
	/// The relationships for the manga
	/// </summary>
	public class MangaRelationships
	{
		/// <summary>
		/// The cover for the manga
		/// </summary>
		[JsonPropertyName("cover")]
		public WdManga.CoverImage Cover { get; set; } = new();

		/// <summary>
		/// The tags of the manga
		/// </summary>
		[JsonPropertyName("tags")]
		public WdPagedEntity[] Tags { get; set; } = [];

		/// <summary>
		/// The available languages for the manga
		/// </summary>
		[JsonPropertyName("available_languages")]
		public string[] AvailableLanguages { get; set; } = [];
	}
}

/// <summary>
/// The base data for a manga
/// </summary>
public abstract class WdMangaBase
{
	/// <summary>
	/// The ID of the manga
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// The title of the manga
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = string.Empty;

	/// <summary>
	/// The year the manga was released
	/// </summary>
	[JsonPropertyName("year")]
	public int Year { get; set; }

	/// <summary>
	/// The language (code) the manga was original released in
	/// </summary>
	[JsonPropertyName("language")]
	public string Language { get; set; } = string.Empty;

	/// <summary>
	/// The demographic for the manga
	/// </summary>
	[JsonPropertyName("demographic")]
	public Demographic Demographic { get; set; }

	/// <summary>
	/// The publication status for the manga
	/// </summary>
	[JsonPropertyName("status")]
	public MangaStatus Status { get; set; }

	/// <summary>
	/// The content rating for the manga
	/// </summary>
	[JsonPropertyName("content_rating")]
	public ContentRating Rating { get; set; }

	/// <summary>
	/// When the manga was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	/// <summary>
	/// When the manga was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }
}

/// <summary>
/// Represents a paginated response containing a list of manga entries from the WeebDex API.
/// </summary>
public class WdMangaList : WeebDexPageResponse<WdMangaPartial> { }

/// <summary>
/// Represents an aggregate set of the manga's chapters and volumes
/// </summary>
public class WdMangaAggregates
{
	/// <summary>
	/// All of the languages (codes) that have chapters for this manga
	/// </summary>
	[JsonPropertyName("languages")]
	public string[] Languages { get; set; } = [];

	/// <summary>
	/// All of the groups that have translated chapters for this manga
	/// </summary>
	[JsonPropertyName("groups")]
	public WdEntity[] Groups { get; set; } = [];

	/// <summary>
	/// The chapters in the manga aggregate
	/// </summary>
	[JsonPropertyName("chapters")]
	public Entry[] Chapters { get; set; } = [];

	/// <summary>
	/// The aggregate entries
	/// </summary>
	public class Entry
	{
		/// <summary>
		/// The volume number the chapters belong to
		/// </summary>
		[JsonPropertyName("volume")]
		public string? Volume { get; set; }

		/// <summary>
		/// The chapter number
		/// </summary>
		[JsonPropertyName("chapter")]
		public string Chapter { get; set; } = string.Empty;

		/// <summary>
		/// All of the chapters that belong to this volume and chapter number
		/// </summary>
		[JsonPropertyName("entries")]
		public Dictionary<string, ChapterEntry> Entries { get; set; } = [];
	}

	/// <summary>
	/// The aggregate entry for the manga's chapters
	/// </summary>
	public class ChapterEntry
	{
		/// <summary>
		/// The date and time the chapter was published
		/// </summary>
		[JsonPropertyName("published_at")]
		public DateTimeOffset PublishedAt { get; set; }

		/// <summary>
		/// The index of the language in the <see cref="Languages"/> array
		/// </summary>
		[JsonPropertyName("language")]
		public int Language { get; set; }

		/// <summary>
		/// The indices of the groups in the <see cref="Groups"/> array
		/// </summary>
		[JsonPropertyName("groups")]
		public int[] Groups { get; set; } = [];
	}
}

/// <summary>
/// The various filters for searching manga
/// </summary>
public class WdMangaFilter
{
	/// <summary>
	/// The IDs of the artists to include manga for
	/// </summary>
	public string[] Artists { get; set; } = [];

	/// <summary>
	/// The IDs of the authors to include manga for
	/// </summary>
	public string[] Authors { get; set; } = [];

	/// <summary>
	/// The author or artist name to filter by
	/// </summary>
	public string? AuthorOrArtist { get; set; }

	/// <summary>
	/// The codes of the Translated Languages to include chapters for
	/// </summary>
	public string[] AvailableTranslatedLanguages { get; set; } = [];

	/// <summary>
	/// The content rating to filter by
	/// </summary>
	public ContentRating[] Rating { get; set; } = [ContentRating.Safe, ContentRating.Suggestive, ContentRating.Erotica, ContentRating.Pornographic];

	/// <summary>
	/// The demographics to filter by
	/// </summary>
	public Demographic[] Demographics { get; set; } = [];

	/// <summary>
	/// The group who submitted the manga
	/// </summary>
	public string? Group { get; set; }

	/// <summary>
	/// Whether or not the manga needs to have chapters
	/// </summary>
	public bool? HasChapters { get; set; }

	/// <summary>
	/// The codes of the languages to include manga for
	/// </summary>
	public string[] LanguagesInclude { get; set; } = [];

	/// <summary>
	/// The codes of the languages to exclude manga for
	/// </summary>
	public string[] LanguagesExclude { get; set; } = [];

	/// <summary>
	/// The total number of chapters to request at one time
	/// </summary>
	public int Limit { get; set; } = 100;

	/// <summary>
	/// Whether or order the results in ascending or descending order
	/// </summary>
	public bool? Descending { get; set; }

	/// <summary>
	/// The page of results to return
	/// </summary>
	public int Page { get; set; } = 1;

	/// <summary>
	/// The sorting criteria for the manga
	/// </summary>
	public MangaSort? Sort { get; set; }

	/// <summary>
	/// The manga status to filter by
	/// </summary>
	public MangaStatus[] Status { get; set; } = [];

	/// <summary>
	/// The IDs of the Tags to include manga for
	/// </summary>
	public string[] TagsInclude { get; set; } = [];

	/// <summary>
	/// The IDs of the Tags to exclude manga for
	/// </summary>
	public string[] TagsExclude { get; set; } = [];

	/// <summary>
	/// The mode for tag includes
	/// </summary>
	public ParamMode TagIncludeMode { get; set; } = ParamMode.And;

	/// <summary>
	/// The mode for tag exclusions
	/// </summary>
	public ParamMode TagExcludeMode { get; set; } = ParamMode.Or;

	/// <summary>
	/// The title of the manga to search for
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Filter based on the release year for the manga
	/// </summary>
	public int? YearFrom { get; set; }

	/// <summary>
	/// Filter based on the release year for the manga
	/// </summary>
	public int? YearTo { get; set; }

	/// <summary>
	/// Builds the query parameters for the filter
	/// </summary>
	/// <returns>The query parameters</returns>
	public string BuildQuery()
	{
		return new FilterBuilder()
			.Add("artist", Artists)
			.Add("author", Authors)
			.Add("authorOrArtist", AuthorOrArtist)
			.Add("availableTranslatedLang", AvailableTranslatedLanguages)
			.Add("contentRating", Rating, true)
			.Add("demographic", Demographics, true)
			.Add("group", Group)
			.Add("hasChapters", HasChapters)
			.Add("lang", LanguagesInclude)
			.Add("langx", LanguagesExclude)
			.Add("limit", Limit)
			.Add("order", Descending is null ? null : Descending.Value ? "desc" : "asc")
			.Add("page", Page)
			.Add("sort", Sort)
			.Add("status", Status, true)
			.Add("tag", TagsInclude)
			.Add("tagx", TagsExclude)
			.Add("title", Title)
			.Add("tmode", TagIncludeMode.ToString().ToLower())
			.Add("txmode", TagExcludeMode.ToString().ToLower())
			.Add("yearFrom", YearFrom)
			.Add("yearTo", YearTo)
			.Build();
	}
}

/// <summary>
/// Query builder for filtering a manga's chapters
/// </summary>
public class WdMangaChapterFilter
{
	/// <summary>
	/// The IDs of the groups to include chapters for
	/// </summary>
	public string[] GroupsInclude { get; set; } = [];

	/// <summary>
	/// The IDs of the groups to exclude chapters for
	/// </summary>
	public string[] GroupsExclude { get; set; } = [];

	/// <summary>
	/// Whether or order the results in ascending or descending order
	/// </summary>
	public bool? Descending { get; set; }

	/// <summary>
	/// The total number of chapters to request at one time
	/// </summary>
	public int Limit { get; set; } = 100;

	/// <summary>
	/// The page of results to return
	/// </summary>
	public int Page { get; set; } = 1;

	/// <summary>
	/// The codes of the Translated Languages to include chapters for
	/// </summary>
	public string[] TranslatedLanguagesInclude { get; set; } = [];

	/// <summary>
	/// The codes of the Translated Languages to exclude chapters for
	/// </summary>
	public string[] TranslatedLanguagesExclude { get; set; } = [];

	/// <summary>
	/// The IDs of the Uploaders to include chapters for
	/// </summary>
	public string[] UploadersInclude { get; set; } = [];

	/// <summary>
	/// The IDs of the Uploaders to exclude chapters for
	/// </summary>
	public string[] UploadersExclude { get; set; } = [];

	/// <summary>
	/// Whether or sort by name or publishedAt
	/// </summary>
	public bool? SortName { get; set; }

	/// <summary>
	/// Builds the query parameters for the filter
	/// </summary>
	/// <returns>The query parameters</returns>
	public string BuildQuery()
	{
		return new FilterBuilder()
			.Add("group", GroupsInclude)
			.Add("groupx", GroupsExclude)
			.Add("limit", Limit)
			.Add("page", Page)
			.Add("order", Descending is null ? null : Descending.Value ? "desc" : "asc")
			.Add("sort", SortName is null ? null : SortName.Value ? "name" : "publishedAt")
			.Add("tlang", TranslatedLanguagesInclude)
			.Add("tlangx", TranslatedLanguagesExclude)
			.Add("uploader", UploadersInclude)
			.Add("uploaderx", UploadersExclude)
			.Build();
	}
}