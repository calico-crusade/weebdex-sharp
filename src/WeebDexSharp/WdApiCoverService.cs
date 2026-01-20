namespace WeebDexSharp;

/// <summary>
/// A service for interfacing with cover endpoints in the WeebDex API
/// </summary>
/// <remarks>TODO: Uploading covers</remarks>
public interface IWdApiCoverService
{
	/// <summary>
	/// Gets a cover by it's ID
	/// </summary>
	/// <param name="id">The ID of the cover</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdCover>> Get(string id,  CancellationToken token = default);

	/// <summary>
	/// Updates the cover data information
	/// </summary>
	/// <param name="id">The ID of the cover to update</param>
	/// <param name="data">The data to update</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdCover>> Update(string id, WdCover.Create data, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Deletes the give cover
	/// </summary>
	/// <param name="id">The ID of the cover</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Delete(string id, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Gets all of the covers for the given manga
	/// </summary>
	/// <param name="id">The ID of the manga</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdCover[]>> ForManga(string id, CancellationToken token = default);
}

internal class WdApiCoverService(
	IWdApiService _api) : IWdApiCoverService
{
	public Task<WeebDexResponse> Delete(string id, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Delete($"/cover/{id}", true, creds, token);
	}

	public Task<WeebDexResponse<WdCover[]>> ForManga(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdCover[]>>($"/manga/{id}/covers", token: token);
	}

	public Task<WeebDexResponse<WdCover>> Get(string id, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdCover>>($"/cover/{id}", token: token);
	}

	public Task<WeebDexResponse<WdCover>> Update(string id, WdCover.Create data, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Put<WdCover.Create, WeebDexResponse<WdCover>>($"/cover/{id}", data, true, creds, token);
	}
}
