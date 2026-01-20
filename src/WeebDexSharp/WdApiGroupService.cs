namespace WeebDexSharp;

/// <summary>
/// A service for interfacing with scanlation groups in the WeebDex API
/// </summary>
public interface IWdApiGroupService
{
	/// <summary>
	/// Fetches a paged list of scanlation groups
	/// </summary>
	/// <param name="ids">The IDs of the groups to fetch</param>
	/// <param name="name">The name of the group to fetch</param>
	/// <param name="limit">The total number of items to return</param>
	/// <param name="page">The page number to fetch</param>
	/// <param name="token">A cancellation token</param>
	/// <returns>The groups</returns>
	Task<WdGroupList> List(string[]? ids = null, string? name = null, int limit = 100, int page = 1, CancellationToken token = default);

	/// <summary>
	/// Fetches a single group
	/// </summary>
	/// <param name="id">The ID of the group</param>
	/// <param name="token">A cancellation token</param>
	/// <returns>The group</returns>
	Task<WeebDexResponse<WdGroup>> Get(string id, CancellationToken token = default);

	/// <summary>
	/// Creates a group
	/// </summary>
	/// <param name="group">The data of the group</param>
	/// <param name="creds">The credentials to use for authentication</param>
	/// <param name="token">A cancellation token</param>
	/// <returns>The created group</returns>
	Task<WeebDexResponse<WdGroup>> Create(WdGroup.Create group, Credentials? creds = null,  CancellationToken token = default);

	/// <summary>
	/// Updates a group
	/// </summary>
	/// <param name="id">The ID of the group to update</param>
	/// <param name="update">The group data</param>
	/// <param name="creds">The credentials to use for authentication</param>
	/// <param name="token">A cancellation token</param>
	/// <returns>The updated group</returns>
	Task<WeebDexPageResponse<WdGroup>> Update(string id, WdGroup.Update update, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Gets the stats for a specific group
	/// </summary>
	/// <param name="id">The ID of the group</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The ratings</returns>
	Task<WeebDexResponse<WdGroupRating>> Statistics(string id, CancellationToken token = default);
}

internal class WdApiGroupService(
	IWdApiService _api,
	IWdApiStatisticsService _stats) : IWdApiGroupService
{
	public Task<WeebDexResponse<WdGroup>> Create(WdGroup.Create group, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Post<WdGroup.Create, WeebDexResponse<WdGroup>>("/group", group, true, creds, token);
	}

	public Task<WeebDexResponse<WdGroup>> Get(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdGroup>>($"/group/{id}", token: token);
	}

	public Task<WdGroupList> List(string[]? ids = null, string? name = null, int limit = 100, int page = 1, CancellationToken token = default)
	{
		var pars = new FilterBuilder()
			.Add("id", ids ?? [])
			.Add("limit", limit)
			.Add("page", page)
			.Add("name", name)
			.Build();
		return _api.Get<WdGroupList>($"/group?{pars}", token: token);
	}

	public Task<WeebDexResponse<WdGroupRating>> Statistics(string id, CancellationToken token = default)
	{
		return _stats.Group(id, token);
	}

	public Task<WeebDexPageResponse<WdGroup>> Update(string id, WdGroup.Update update, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Put<WdGroup.Update, WeebDexPageResponse<WdGroup>>($"/group/{id}", update, true, creds, token);
	}
}
