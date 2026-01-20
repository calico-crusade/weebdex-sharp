namespace WeebDexSharp;

/// <summary>
/// The service for interacting with manga in the WeebDex API
/// </summary>
public interface IWdApiMangaService
{
	/// <summary>
	/// Allows for searching for manga with various filters
	/// </summary>
	/// <param name="filter">The filter to apply to the search</param>
	/// <param name="token">The cancellation token of the search operation</param>
	/// <returns>The search results</returns>
	Task<WdMangaList> Search(WdMangaFilter? filter = null, CancellationToken token = default);

	/// <summary>
	/// Searchs for a random manga with optional filters
	/// </summary>
	/// <param name="filter">The filter to apply to the search</param>
	/// <param name="token">The cancellation token of the search operation</param>
	/// <returns>The search results</returns>
	Task<WeebDexResponse<WdManga>> Random(WdMangaFilter? filter = null, CancellationToken token = default);

	/// <summary>
	/// Gets all of the related manga for a given manga ID
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="token">The cancellation token of the operation</param>
	/// <returns>The related manga</returns>
	Task<WeebDexResponse<WdManga.RelatedManga[]>> Relations(string id, CancellationToken token = default);

	/// <summary>
	/// Creates a relationship between two manga
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="relation">The relationship data</param>
	/// <param name="creds">The credentials for authentication</param>
	/// <param name="token">The cancellation token of the operation</param>
	/// <returns>The created related manga</returns>
	Task<WeebDexResponse<WdManga.RelatedManga>> CreateRelation(string id, WdManga.CreateRelation relation, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Deletes a relationship between two manga
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="relatedId">The ID of the related manga</param>
	/// <param name="creds">The credentials for authentication</param>
	/// <param name="token">The cancellation token of the operation</param>
	/// <returns>The response to the request</returns>
	Task<WeebDexResponse> DeleteRelation(string id, string relatedId, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Fetches the top chapters over a period of time
	/// </summary>
	/// <param name="rating">The content rating to filter by</param>
	/// <param name="limit">The maximum number of chapters to retrieve</param>
	/// <param name="page">The page number to retrieve</param>
	/// <param name="time">The time frame for which to retrieve top chapters</param>
	/// <param name="rankViews">Whether to rank by views instead of read</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>A list of top chapters matching the criteria</returns>
	Task<WdMangaList> Top(ContentRating[]? rating = null, int limit = 100, int page = 1, TimeFrame time = TimeFrame.SevenDays, bool rankViews = true, CancellationToken token = default);

	/// <summary>
	/// Gets a manga by its ID
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The manga</returns>
	Task<WeebDexResponse<WdManga>> Get(string id, CancellationToken token = default);

	/// <summary>
	/// Gets all of the recommended manga for the given manga
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="token">The cancellation token of the search operation</param>
	/// <returns>The search results</returns>
	Task<WdMangaList> Recommendations(string id, CancellationToken token = default);

	/// <summary>
	/// Fetches a list of all of the chapters for a given manga ID
	/// </summary>
	/// <param name="id">The Id of the manga</param>
	/// <param name="filter">The filter options</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The chapters</returns>
	Task<WdChapterList> Chapters(string id, WdMangaChapterFilter? filter = null, CancellationToken token = default);

	/// <summary>
	/// Provides aggregate information about a manga's chapters across different languages and groups
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="languages">The translated languages to include in the aggregate</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The aggregate information</returns>
	Task<WeebDexResponse<WdMangaAggregates>> Aggregate(string id, string[]? languages = null, CancellationToken token = default);
}

internal class WdApiMangaService(
	IWdApiService _api) : IWdApiMangaService
{
	public Task<WeebDexResponse<WdMangaAggregates>> Aggregate(string id, string[]? languages = null, CancellationToken token = default)
	{
		var pars = new FilterBuilder()
			.Add("tlang", languages ?? [])
			.Build();
		return _api.Get<WeebDexResponse<WdMangaAggregates>>($"/manga/{id}/aggregate?{pars}", token: token);
	}

	public Task<WdChapterList> Chapters(string id, WdMangaChapterFilter? filter = null, CancellationToken token = default)
	{
		filter ??= new();
		return _api.Get<WdChapterList>($"/manga/{id}/chapters?{filter.BuildQuery()}", token: token);
	}

	public Task<WeebDexResponse<WdManga.RelatedManga>> CreateRelation(string id, WdManga.CreateRelation relation, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Post<WdManga.CreateRelation, WeebDexResponse<WdManga.RelatedManga>>($"/manga/{id}/relations", relation, true, creds, token);
	}

	public Task<WeebDexResponse> DeleteRelation(string id, string relatedId, Credentials? creds = null, CancellationToken token = default)
	{
		var body = new WdManga.DeleteRelation
		{
			Id = relatedId
		};
		return _api.Delete($"/manga/{id}/relations", body, true, creds, token);
	}

	public Task<WeebDexResponse<WdManga>> Get(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdManga>>($"/manga/{id}", token: token);
	}

	public Task<WeebDexResponse<WdManga>> Random(WdMangaFilter? filter = null, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdManga>>($"/manga/random?{filter?.BuildQuery()}", token: token);
	}

	public Task<WdMangaList> Recommendations(string id, CancellationToken token = default)
	{
		return _api.Get<WdMangaList>($"/manga/{id}/recommendations", token: token);
	}

	public Task<WeebDexResponse<WdManga.RelatedManga[]>> Relations(string id, CancellationToken token)
	{
		return _api.Get<WeebDexResponse<WdManga.RelatedManga[]>>($"/manga/{id}/relations", token: token);
	}

	public Task<WdMangaList> Search(WdMangaFilter? filter, CancellationToken token)
	{
		filter ??= new();
		return _api.Get<WdMangaList>($"/manga?{filter.BuildQuery()}", token: token);
	}

	public Task<WdMangaList> Top(ContentRating[]? rating = null, int limit = 100, int page = 1, TimeFrame time = TimeFrame.SevenDays, bool rankViews = true, CancellationToken token = default)
	{
		string? frame = time switch
		{
			TimeFrame.TwentyFourHours => "24h",
			TimeFrame.SevenDays => "7d",
			TimeFrame.ThirtyDays => "30d",
			_ => null
		};
		var filter = new FilterBuilder()
			.Add("limit", limit)
			.Add("page", page)
			.Add("time", frame)
			.Add("contentRating", rating ?? [])
			.Add("rank", rankViews ? "views" : "read")
			.Build();
		return _api.Get<WdMangaList>($"/manga/top?{filter}", token: token);
	}
}
