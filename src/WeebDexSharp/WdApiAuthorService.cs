namespace WeebDexSharp;

/// <summary>
/// Represents a service that handles author related features in WeebDex
/// </summary>
public interface IWdApiAuthorService
{
	/// <summary>
	/// A paginated list of all authors
	/// </summary>
	/// <param name="name">The name to search for (optional)</param>
	/// <param name="ids">The IDs of the authors to search for (optional)</param>
	/// <param name="limit">The maximum number of authors to return per page (optional, default is 100)</param>
	/// <param name="page">The page number to return (optional, default is 1)</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>A paginated list of authors</returns>
	Task<WdEntities> List(string? name = null, string[]? ids = null, int limit = 100, int page = 1, CancellationToken token = default);

	/// <summary>
	/// Fetches an author by it's ID
	/// </summary>
	/// <param name="id">The ID of the author</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdAuthor>> Get(string id, CancellationToken token = default);

	/// <summary>
	/// Creates an author with the given data
	/// </summary>
	/// <param name="data">The data for the new author</param>
	/// <param name="creds">The credentials to use for authentication (optional)</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response containing the created author</returns>
	Task<WeebDexResponse<WdAuthor>> Create(AuthorData data, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Updates an author with the given data
	/// </summary>
	/// <param name="id">The ID of the author to update</param>
	/// <param name="data">The data for the new author</param>
	/// <param name="creds">The credentials to use for authentication (optional)</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response containing the created author</returns>
	Task<WeebDexResponse<WdAuthor>> Update(string id, AuthorData data, Credentials? creds = null, CancellationToken token = default);
}

internal class WdApiAuthorService(
	IWdApiService _api) : IWdApiAuthorService
{
	public Task<WeebDexResponse<WdAuthor>> Create(AuthorData data, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Post<AuthorData, WeebDexResponse<WdAuthor>>("/author", data, true, creds, token);
	}

	public Task<WeebDexResponse<WdAuthor>> Get(string id, CancellationToken token)
	{
		return _api.Get<WeebDexResponse<WdAuthor>>($"/author/{id}", token: token);
	}

	public Task<WdEntities> List(string? name = null, string[]? ids = null, int limit = 100, int page = 1, CancellationToken token = default)
	{
		var pars = new FilterBuilder()
			.Add("name", name)
			.Add("ids", ids ?? [])
			.Add("limit", limit)
			.Add("page", page)
			.Build();
		return _api.Get<WdEntities>($"/author?{pars}", token: token);
	}

	public Task<WeebDexResponse<WdAuthor>> Update(string id, AuthorData data, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Put<AuthorData, WeebDexResponse<WdAuthor>>($"/author/{id}", data, true, creds, token);
	}
}
