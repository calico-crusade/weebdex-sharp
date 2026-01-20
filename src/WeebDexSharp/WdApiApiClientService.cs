namespace WeebDexSharp;

/// <summary>
/// A service for interfacing with API clients on WeebDex
/// </summary>
public interface IWdApiApiClientService
{
	/// <summary>
	/// Fetches all of the current user's API clients
	/// </summary>
	/// <param name="creds">The user's API credentials</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdApiClient[]>> Get(Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Creates an API client
	/// </summary>
	/// <param name="name">The name of the client to create</param>
	/// <param name="creds">The user's API credentials</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdApiClientWithSecret>> Create(string name, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Updates an API client
	/// </summary>
	/// <param name="id">The ID of the client to update</param>
	/// <param name="name">The new name of the client</param>
	/// <param name="creds">The user's API credentials</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdApiClient>> Update(string id, string name, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Deletes an API client
	/// </summary>
	/// <param name="id">The ID of the client to delete</param>
	/// <param name="creds">The user's API credentials</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Delete(string id, Credentials? creds = null, CancellationToken token = default);

	/// <summary>
	/// Regenerates an API client's secret key
	/// </summary>
	/// <param name="id">The ID of the client to regenerate the key for</param>
	/// <param name="creds">The user's API credentials</param>
	/// <param name="token">The cancellation token for the request</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse<WdApiClientWithSecret>> Regenerate(string id, Credentials? creds = null, CancellationToken token = default);
}

internal class WdApiApiClientService(
	IWdApiService _api) : IWdApiApiClientService
{
	public Task<WeebDexResponse<WdApiClientWithSecret>> Create(string name, Credentials? creds = null, CancellationToken token = default)
	{
		var body = new WdApiClient.Data { Name = name };
		return _api.Post<WdApiClient.Data, WeebDexResponse<WdApiClientWithSecret>>("/client", body, true, creds, token);
	}

	public Task<WeebDexResponse> Delete(string id, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Delete<WeebDexResponse>($"/client/{id}", true, creds, token);
	}

	public Task<WeebDexResponse<WdApiClient[]>> Get(Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Get<WeebDexResponse<WdApiClient[]>>("/client", true, creds, token);
	}

	public Task<WeebDexResponse<WdApiClientWithSecret>> Regenerate(string id, Credentials? creds = null, CancellationToken token = default)
	{
		return _api.Post<WeebDexResponse<WdApiClientWithSecret>>($"/client/{id}/regenerate", true, creds, token);
	}

	public Task<WeebDexResponse<WdApiClient>> Update(string id, string name, Credentials? creds = null, CancellationToken token = default)
	{
		var body = new WdApiClient.Data { Name = name };
		return _api.Put<WdApiClient.Data, WeebDexResponse<WdApiClient>>($"/client/{id}", body, true, creds, token);
	}
}
