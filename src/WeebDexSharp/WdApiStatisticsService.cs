namespace WeebDexSharp;

/// <summary>
/// A service for interfacing with the statistics endpoints of the WeebDex API
/// </summary>
public interface IWdApiStatisticsService
{
	/// <summary>
	/// Gets the stats for a specific chapter
	/// </summary>
	/// <param name="id">The ID of the chapter</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The ratings</returns>
	Task<WeebDexResponse<WdChapterRating>> Chapter(string id, CancellationToken token = default);

	/// <summary>
	/// Gets the stats for a specific group
	/// </summary>
	/// <param name="id">The ID of the group</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The ratings</returns>
	Task<WeebDexResponse<WdGroupRating>> Group(string id, CancellationToken token = default);

	/// <summary>
	/// Gets the stats for a specific manga
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The ratings</returns>
	Task<WeebDexResponse<WdMangaRating>> Manga(string id, CancellationToken token = default);

	/// <summary>
	/// Gets the stats for a specific user
	/// </summary>
	/// <param name="id">The ID of the user</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The ratings</returns>
	Task<WeebDexResponse<WdUserRating>> User(string id, CancellationToken token = default);
}

internal class WdApiStatisticsService(
	IWdApiService _api) : IWdApiStatisticsService
{
	public Task<WeebDexResponse<WdChapterRating>> Chapter(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdChapterRating>>($"/chapter/{id}/statistics", token:token);
	}

	public Task<WeebDexResponse<WdGroupRating>> Group(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdGroupRating>>($"/group/{id}/statistics", token: token);
	}

	public Task<WeebDexResponse<WdMangaRating>> Manga(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdMangaRating>>($"/manga/{id}/statistics", token: token);
	}

	public Task<WeebDexResponse<WdUserRating>> User(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdUserRating>>($"/user/{id}/statistics", token: token);
	}
}
