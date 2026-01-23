namespace WeebDexSharp.Models;

/// <summary>
/// Represents a chapter in a manga
/// </summary>
public class WdChapter : WdChapterBase
{
	/// <summary>
	/// The image file names for the chapter
	/// </summary>
	[JsonPropertyName("data")]
	public WdImage[] Data { get; set; } = [];

	/// <summary>
	/// The image file names for the chapter that have been optimized (webp)
	/// </summary>
	[JsonPropertyName("data_optimized")]
	public WdImage[] DataOptimized { get; set; } = [];

	/// <summary>
	/// The node the chapter images are available on
	/// </summary>
	[JsonPropertyName("node")]
	public string Node { get; set; } = string.Empty;

	/// <summary>
	/// The related data for this chapter
	/// </summary>
	[JsonPropertyName("relationships")]
	public ChapterRelationships Relationships { get; set; } = new();

	/// <summary>
	/// The full image URLs from <see cref="DataOptimized"/>
	/// </summary>
	[JsonIgnore]
	public IEnumerable<WdImage> ImageUrlsOptimized => DataOptimized.Select(Scope);

	/// <summary>
	/// The full image URLs from <see cref="Data"/>
	/// </summary>
	[JsonIgnore]
	public IEnumerable<WdImage> ImageUrls => Data.Select(Scope);

	internal WdImage Scope(WdImage image)
	{
		return new WdImage
		{
			Name = $"{Node.TrimEnd('/')}/data/{Id}/{image.Name.TrimStart('/')}",
			Dimensions = image.Dimensions
		};
	}

	/// <summary>
	/// The data of a chapter that can be updated
	/// </summary>
	public class Update
	{
		/// <summary>
		/// The chapter number
		/// </summary>
		[JsonPropertyName("chapter")]
		public string? Chapter { get; set; }

		/// <summary>
		/// The ID of the groups involved in the chapter
		/// </summary>
		[JsonPropertyName("groups")]
		public string[]? Groups { get; set; }

		/// <summary>
		/// The language code for the chapter
		/// </summary>
		[JsonPropertyName("language")]
		public string? Language { get; set; }

		/// <summary>
		/// The chapter title
		/// </summary>
		[JsonPropertyName("title")]
		public string? Title { get; set; }

		/// <summary>
		/// The volume number
		/// </summary>
		[JsonPropertyName("volume")]
		public string? Volume { get; set; }

		/// <summary>
		/// The version number of the chapter
		/// </summary>
		[JsonPropertyName("version")]
		public int Version { get; set; }
	}

	/// <summary>
	/// Represents all of the data related to the chapter
	/// </summary>
	public class ChapterRelationships
	{
		/// <summary>
		/// The user who uploaded the chapter
		/// </summary>
		[JsonPropertyName("uploader")]
		public ChapterUploader Uploader { get; set; } = new();

		/// <summary>
		/// All of the groups involved in uploading the chapter
		/// </summary>
		[JsonPropertyName("groups")]
		public WdEntity[] Groups { get; set; } = [];

		/// <summary>
		/// The chapter statistics
		/// </summary>
		[JsonPropertyName("stats")]
		public WdChapterRating Stats { get; set; } = new();

		/// <summary>
		/// The information about the chapter's comment thread
		/// </summary>
		[JsonPropertyName("thread")]
		public WdThread Thread { get; set; } = new();
	}

	/// <summary>
	/// Represents someone who uploaded the chapter
	/// </summary>
	public class ChapterUploader : WdEntity
	{
		/// <summary>
		/// The roles the user has
		/// </summary>
		[JsonPropertyName("roles")]
		public string[] Roles { get; set; } = [];
	}
}

/// <summary>
/// The partial data for <see cref="WdChapter"/>s
/// </summary>
public class WdChapterPartial : WdChapterBase
{
	/// <summary>
	/// The related data for this chapter
	/// </summary>
	[JsonPropertyName("relationships")]
	public ChapterRelationships Relationships { get; set; } = new();

	/// <summary>
	/// Represents all of the data related to the chapter
	/// </summary>
	public class ChapterRelationships
	{
		/// <summary>
		/// The user who uploaded the chapter
		/// </summary>
		[JsonPropertyName("uploader")]
		public WdChapter.ChapterUploader Uploader { get; set; } = new();

		/// <summary>
		/// All of the groups involved in uploading the chapter
		/// </summary>
		[JsonPropertyName("groups")]
		public WdEntity[] Groups { get; set; } = [];

		/// <summary>
		/// The chapter statistics
		/// </summary>
		[JsonPropertyName("stats")]
		public WdChapterRating Stats { get; set; } = new();

		/// <summary>
		/// The manga the chapter belongs to
		/// </summary>
		[JsonPropertyName("manga")]
		public WdMangaPartial Manga { get; set; } = new();
	}
}

/// <summary>
/// Represents a paged response containing a list of chapter summaries and associated mapping data from the WeebDex API.
/// </summary>
public class WdChapterList : WeebDexPageResponse<WdChapterPartial> 
{
	/// <summary>
	/// Extra map data
	/// </summary>
	[JsonPropertyName("map")]
	public ChapterMap Map { get; set; } = new();

	/// <summary>
	/// The map data
	/// </summary>
	public class ChapterMap
	{
		/// <summary>
		/// The manga related to the chapters
		/// </summary>
		[JsonPropertyName("manga")]
		public Dictionary<string, WdMangaPartial> Manga { get; set; } = [];
	}
}

/// <summary>
/// The base data for chapters
/// </summary>
public abstract class WdChapterBase
{
	private PublicationState? _state;

	/// <summary>
	/// The ID of the chapter
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// The chapter number
	/// </summary>
	[JsonPropertyName("chapter")]
	public string Chapter { get; set; } = string.Empty;

	/// <summary>
	/// The volume the chapter belongs to
	/// </summary>
	[JsonPropertyName("volume")]
	public string? Volume { get; set; }

	/// <summary>
	/// The title of the chapter
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = string.Empty;

	/// <summary>
	/// When the chapter was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	/// <summary>
	/// When the chapter was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }

	/// <summary>
	/// When the chapter was deleted
	/// </summary>
	[JsonPropertyName("deleted_at")]
	public DateTimeOffset? DeletedAt { get; set; }

	/// <summary>
	/// When the chapter was published
	/// </summary>
	[JsonPropertyName("published_at")]
	public DateTimeOffset? PublishedAt { get; set; }

	/// <summary>
	/// Whether or not the chapter pages are unavailable
	/// </summary>
	[JsonPropertyName("is_unavailable")]
	public bool IsUnavailable { get; set; }

	/// <summary>
	/// The language code of the chapter
	/// </summary>
	[JsonPropertyName("language")]
	public string Language { get; set; } = string.Empty;

	/// <summary>
	/// The version of the chapter
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }

	/// <summary>
	/// The state of the chapter
	/// </summary>
	[JsonPropertyName("state")]
	public PublicationState State
	{
		get => _state ?? (PublishedAt is not null ? PublicationState.Published : PublicationState.Unknown);
		set => _state = value;
	}
}

/// <summary>
/// The various filters for searching chapters
/// </summary>
public class WdChapterFilter
{
	/// <summary>
	/// The IDs of the artists to include chapters for
	/// </summary>
	public string[] Artists { get; set; } = [];

	/// <summary>
	/// The IDs of the authors to include chapters for
	/// </summary>
	public string[] Authors { get; set; } = [];

	/// <summary>
	/// The author or artist name to filter by
	/// </summary>
	public string? AuthorOrArtist { get; set; }

	/// <summary>
	/// The content rating to filter by
	/// </summary>
	public ContentRating[] Rating { get; set; } = [ContentRating.Safe, ContentRating.Suggestive, ContentRating.Erotica, ContentRating.Pornographic];

	/// <summary>
	/// The demographics to filter by
	/// </summary>
	public Demographic[] Demographics { get; set; } = [];

	/// <summary>
	/// The manga status to filter by
	/// </summary>
	public MangaStatus[] Status { get; set; } = [];

	/// <summary>
	/// The IDs of the groups to include chapters for
	/// </summary>
	public string[] GroupsInclude { get; set; } = [];

	/// <summary>
	/// The IDs of the groups to exclude chapters for
	/// </summary>
	public string[] GroupsExclude { get; set; } = [];

	/// <summary>
	/// The codes of the languages to include chapters for
	/// </summary>
	public string[] LanguagesInclude { get; set; } = [];

	/// <summary>
	/// The codes of the languages to exclude chapters for
	/// </summary>
	public string[] LanguagesExclude { get; set; } = [];

	/// <summary>
	/// The IDs of the Tags to include chapters for
	/// </summary>
	public string[] TagsInclude { get; set; } = [];

	/// <summary>
	/// The IDs of the Tags to exclude chapters for
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
	/// Builds the query parameters for the filter
	/// </summary>
	/// <returns>The query parameters</returns>
	public string BuildQuery()
	{
		return new FilterBuilder()
			.Add("artist", Artists)
			.Add("author", Authors)
			.Add("authorOrArtist", AuthorOrArtist)
			.Add("contentRating", Rating, true)
			.Add("demographic", Demographics, true)
			.Add("group", GroupsInclude)
			.Add("groupx", GroupsExclude)
			.Add("lang", LanguagesInclude)
			.Add("langx", LanguagesExclude)
			.Add("limit", Limit)
			.Add("page", Page)
			.Add("order", Descending is null ? null : Descending.Value ? "desc" : "asc")
			.Add("status", Status, true)
			.Add("tag", TagsInclude)
			.Add("tagx", TagsExclude)
			.Add("tlang", TranslatedLanguagesInclude)
			.Add("tlangx", TranslatedLanguagesExclude)
			.Add("uploader", UploadersInclude)
			.Add("uploaderx", UploadersExclude)
			.Add("tmode", TagIncludeMode.ToString().ToLower())
			.Add("txmode", TagExcludeMode.ToString().ToLower())
			.Build();
	}
}