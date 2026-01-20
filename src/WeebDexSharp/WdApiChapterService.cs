namespace WeebDexSharp;

/// <summary>
/// The service for interacting with chapters in the WeebDex API
/// </summary>
public interface IWdApiChapterService
{
	/// <summary>
	/// The request to update a chapter
	/// </summary>
	/// <param name="id">The ID of the chapter to update</param>
	/// <param name="update">The data of the chapter to update</param>
	/// <param name="creds">The optional credentials for authentication</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The updated chapter</returns>
	Task<WeebDexResponse<WdChapter>> Update(string id, WdChapter.Update update, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Gets a chapter by its ID
	/// </summary>
	/// <param name="id">The ID of the chapter</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The chapter</returns>
	Task<WeebDexResponse<WdChapter>> Get(string id, CancellationToken token = default);

	/// <summary>
	/// Searchs for chapters
	/// </summary>
	/// <param name="filter">The filter to apply to the search</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>A list of chapters matching the filter</returns>
	Task<WdChapterList> Search(WdChapterFilter? filter = null, CancellationToken token = default);

	/// <summary>
	/// Gets only the latest chapter for each manga
	/// </summary>
	/// <param name="filter">The filter to apply to the search</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>A list of chapters matching the filter</returns>
	Task<WdChapterList> Updates(WdChapterFilter? filter = null, CancellationToken token = default);

	/// <summary>
	/// Gets a feed of the chapters
	/// </summary>
	/// <param name="filter">The filter to apply to the search</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>A list of chapters matching the filter</returns>
	Task<WdChapterList> Feed(WdChapterFilter? filter = null, CancellationToken token = default);

	/// <summary>
	/// Fetches the top chapters over a period of time
	/// </summary>
	/// <param name="rating">The content rating to filter by</param>
	/// <param name="limit">The maximum number of chapters to retrieve</param>
	/// <param name="page">The page number to retrieve</param>
	/// <param name="time">The time frame for which to retrieve top chapters</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>A list of top chapters matching the criteria</returns>
	Task<WdChapterList> Top(ContentRating[]? rating = null, int limit = 100, int page = 1, TimeFrame time = TimeFrame.SevenDays, CancellationToken token = default);

	/// <summary>
	/// Deletes a chapter by it's ID
	/// </summary>
	/// <param name="id">The ID of the chapter to delete</param>
	/// <param name="creds">The optional credentials for authentication</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response from the delete operation</returns>
	Task<WeebDexResponse> Delete(string id, Credentials? creds = null, CancellationToken token = default);
}

internal class WdApiChapterService(
	IWdApiService _api) : IWdApiChapterService
{
	public Task<WeebDexResponse<WdChapter>> Get(string id, CancellationToken token)
	{
		return _api.Get<WeebDexResponse<WdChapter>>($"/chapter/{id}", token: token);
	}

	public Task<WdChapterList> Search(WdChapterFilter? filter, CancellationToken token)
	{
		filter ??= new();
		return _api.Get<WdChapterList>($"/chapter?{filter.BuildQuery()}", token: token);
	}

	public Task<WdChapterList> Updates(WdChapterFilter? filter, CancellationToken token)
	{
		filter ??= new();
		return _api.Get<WdChapterList>($"/chapter/updates?{filter.BuildQuery()}", token: token);
	}

	public Task<WeebDexResponse<WdChapter>> Update(string id, WdChapter.Update update, Credentials? creds, CancellationToken token)
	{
		return _api.Put<WdChapter.Update, WeebDexResponse<WdChapter>>($"/chapter/{id}", update, true, creds, token);
	}

	public Task<WeebDexResponse> Delete(string id, Credentials? creds, CancellationToken token)
	{
		return _api.Delete<WeebDexResponse>($"/chapter/{id}", true, creds, token);
	}

	public Task<WdChapterList> Feed(WdChapterFilter? filter, CancellationToken token)
	{
		filter ??= new();
		return _api.Get<WdChapterList>($"/chapter/feed?{filter.BuildQuery()}", token: token);
	}

	public Task<WdChapterList> Top(ContentRating[]? rating, int limit, int page, TimeFrame time, CancellationToken token)
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
			.Build();
		return _api.Get<WdChapterList>($"/chapter/top?{filter}", token: token);
	}
}
