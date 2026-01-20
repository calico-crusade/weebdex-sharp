namespace WeebDexSharp.Helpers;

/// <summary>
/// An implementation for executing API requests against WeebDex
/// </summary>
public interface IWdApiService
{
	/// <summary>
	/// Makes a request and fetches it's response
	/// </summary>
	/// <typeparam name="T">The type of response</typeparam>
	/// <param name="url">The URL to make the request to</param>
	/// <param name="method">The HTTP method to use</param>
	/// <param name="content">The content to send with the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response of the request</returns>
	Task<T> Request<T>(string url, HttpMethod method, HttpContent? content, bool authRequired, Credentials? creds, CancellationToken token) 
		where T : WeebDexResponse;

	/// <summary>
	/// Makes a request and fetches it's response
	/// </summary>
	/// <typeparam name="TData">The type of data</typeparam>
	/// <typeparam name="TResp">The type of response</typeparam>
	/// <param name="url">The URL to make the request to</param>
	/// <param name="method">The HTTP method to use</param>
	/// <param name="content">The content to send with the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response of the request</returns>
	Task<TResp> Request<TData, TResp>(string url, HttpMethod method, TData content, bool authRequired, Credentials? creds, CancellationToken token)
		where TResp : WeebDexResponse;

	/// <summary>
	/// Fetch an empty response from the given URL
	/// </summary>
	/// <typeparam name="T">The type of response</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<T> Get<T>(string url, bool authRequired = false, Credentials? creds = null, CancellationToken token = default) 
		where T : WeebDexResponse => Request<T>(url, HttpMethod.Get, null, authRequired, creds, token);

	/// <summary>
	/// Fetch an empty response from the given URL
	/// </summary>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Get(string url, bool authRequired = false, Credentials? creds = null, CancellationToken token = default) 
		=> Get<WeebDexResponse>(url, authRequired, creds, token);

	/// <summary>
	/// Sends an HTTP POST request to the specified URL with the provided data and returns the deserialized response.
	/// </summary>
	/// <typeparam name="TData">The type of data</typeparam>
	/// <typeparam name="TResp">The type of response</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="data">The data for the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<TResp> Post<TData, TResp>(string url, TData data, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		where TResp : WeebDexResponse => Request<TData, TResp>(url, HttpMethod.Post, data, authRequired, creds, token);

	/// <summary>
	/// Sends an HTTP POST request to the specified URL with the provided data and returns the deserialized response.
	/// </summary>
	/// <typeparam name="T">The type of the data to serialize and include in the POST request body.</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="data">The data for the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Post<T>(string url, T data, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		=> Post<T, WeebDexResponse>(url, data, authRequired, creds, token);

	/// <summary>
	/// Sends an HTTP POST request to the specified URL with the provided data and returns the deserialized response.
	/// </summary>
	/// <typeparam name="TData">The type of the data to serialize and include in the POST request body.</typeparam>
	/// <typeparam name="TResp">The type of the response expected from the server. Must inherit from WeebDexResponse.</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="data">The data for the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<TResp> Put<TData, TResp>(string url, TData data, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		where TResp : WeebDexResponse => Request<TData, TResp>(url, HttpMethod.Put, data, authRequired, creds, token);

	/// <summary>
	/// Sends an HTTP POST request to the specified URL with the provided data and returns the deserialized response.
	/// </summary>
	/// <typeparam name="T">The type of the data to serialize and include in the POST request body.</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="data">The data for the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Put<T>(string url, T data, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		=> Put<T, WeebDexResponse>(url, data, authRequired, creds, token);

	/// <summary>
	/// Fetch an empty response from the given URL
	/// </summary>
	/// <typeparam name="T">The type of response</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<T> Delete<T>(string url, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		where T : WeebDexResponse => Request<T>(url, HttpMethod.Delete, null, authRequired, creds, token);

	/// <summary>
	/// Fetch an empty response from the given URL
	/// </summary>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Delete(string url, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		=> Delete<WeebDexResponse>(url, authRequired, creds, token);

	/// <summary>
	/// Sends an HTTP POST request to the specified URL with the provided data and returns the deserialized response.
	/// </summary>
	/// <typeparam name="TData">The type of the data to serialize and include in the POST request body.</typeparam>
	/// <typeparam name="TResp">The type of the response expected from the server. Must inherit from WeebDexResponse.</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="data">The data for the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<TResp> Delete<TData, TResp>(string url, TData data, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		where TResp : WeebDexResponse => Request<TData, TResp>(url, HttpMethod.Delete, data, authRequired, creds, token);

	/// <summary>
	/// Sends an HTTP POST request to the specified URL with the provided data and returns the deserialized response.
	/// </summary>
	/// <typeparam name="T">The type of the data to serialize and include in the POST request body.</typeparam>
	/// <param name="url">The URL to fetch from</param>
	/// <param name="data">The data for the request</param>
	/// <param name="authRequired">Whether or not authentication is required for the request</param>
	/// <param name="creds">The credentials to use for the request</param>
	/// <param name="token">The cancellation token</param>
	/// <returns>The response</returns>
	Task<WeebDexResponse> Delete<T>(string url, T data, bool authRequired = false, Credentials? creds = null, CancellationToken token = default)
		=> Delete<T, WeebDexResponse>(url, data, authRequired, creds, token);
}

internal class WdApiService(
	IHttpClientFactory _factory,
	IWdJsonService _json,
	IApiConfigurationService _api,
	ICredentialsService? _creds,
	WdEventsService _events,
	IWdRequestConfigurationService? _config = null) : IWdApiService
{
	public async Task<bool> Auth(HttpRequestMessage request, bool required, Credentials? creds)
	{
		if (!required) return true;

		if ((creds is null || !creds.IsSet) && _creds is not null)
			creds = await _creds.GetCreds();

		if (creds is null || !creds.IsSet) return false;

		var header = creds.Type == CredentialType.ApiKey ? "Authorization" : "Cookie";
		request.Headers.Add(header, creds.Value!);
		return true;
	}

	public string WrapUrl(string url)
	{
		if (url.StartsWith("http", StringComparison.InvariantCultureIgnoreCase)) return url;
		return $"{_api.ApiUrl.TrimEnd('/')}/{url.TrimStart('/')}";
	}

	public void FillMetaData(string url, HttpResponseMessage resp, HttpRequestMessage request, RequestMetaData data)
	{
		var rateLimits = new RateLimit();

		//TODO: Figure this shit out for weebdex, this is for mangadex
		if (resp.Headers.TryGetValues("X-RateLimit-Limit", out var strLimit) &&
			int.TryParse(strLimit.FirstOrDefault(), out var limit))
			rateLimits.Limit = limit;

		if (resp.Headers.TryGetValues("X-RateLimit-Remaining", out var strRemaining) &&
			int.TryParse(strRemaining.FirstOrDefault(), out var remaining))
			rateLimits.Remaining = remaining;

		if (resp.Headers.TryGetValues("X-RateLimit-Retry-After", out var strRetry) &&
			double.TryParse(strRetry.FirstOrDefault(), out var retry))
			rateLimits.RetryAfter = DateTime.UnixEpoch.AddSeconds(retry);

		data.RateLimits = rateLimits;

		_events.OnRateLimitDataReceived(url, rateLimits);

		if (rateLimits.IsLimited)
			_events.OnRateLimitExceeded(url, rateLimits);

		data.Response.StatusCode = resp.StatusCode;
		data.Response.ReasonPhrase = resp.ReasonPhrase;
		data.Response.Headers = resp.Headers.ToDictionary(h => h.Key, h => h.Value.ToArray());

		data.Request.Headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToArray());
	}

	public async Task<HttpRequestMessage> CreateRequest(RequestMetaData meta, string url, HttpMethod method, HttpContent? content, bool authRequired, Credentials? creds)
	{
		meta.Request.Method = method;
		meta.Request.Uri = url;
		var request = new HttpRequestMessage(method, url)
		{
			Content = content
		};

		if (!string.IsNullOrWhiteSpace(_api.UserAgent))
			request.Headers.UserAgent.ParseAdd(_api.UserAgent);

		if (!await Auth(request, authRequired, creds))
			throw new InvalidOperationException("Authentication is required for this request, but no credentials were provided.");

		_config?.Configure(url, request);
		
		return request;
	}

	public async Task<HttpResponseMessage> DoRequest(RequestMetaData meta, HttpRequestMessage request, string url, CancellationToken token)
	{
		var watch = Stopwatch.StartNew();

		var client = _factory.CreateClient("WeebDexSharp");
		_events.OnRequestStarting(url);
		var response = await client.SendAsync(request, token);
		FillMetaData(url, response, request, meta);
		_events.OnResponseReceived(url, response, request);

		watch.Stop();
		meta.Response.RequestElapsed = watch.Elapsed;
		return response;
	}

	public T HandleJson<T>(string? data) where T : WeebDexResponse
	{
		var type = typeof(T);
		var instance = Activator.CreateInstance<T>();
		if (string.IsNullOrWhiteSpace(data))
			return instance;

		if (!type.IsGenericType ||
			type.GetGenericTypeDefinition() == typeof(WeebDexPageResponse<>) ||
			type.GetGenericTypeDefinition() != typeof(WeebDexResponse<>))
			return _json.Deserialize<T>(data)
				?? throw new InvalidOperationException("Failed to deserialize the response from WeebDex.");

		var property = type.GetProperty(nameof(WeebDexResponse<>.Data));
		var deserialized = _json.Deserialize(data, type.GetGenericArguments()[0])
			?? throw new InvalidOperationException("Failed to deserialize the response from WeebDex.");
		property.SetValue(instance, deserialized);
		return instance;
	}

	public async Task<T> HandleResponse<T>(RequestMetaData meta, HttpResponseMessage response, string url)
		where T : WeebDexResponse
	{
		var watch = Stopwatch.StartNew();

		var respStr = await response.Content.ReadAsStringAsync();
		meta.Response.Body = respStr;
		var data = HandleJson<T>(respStr);

		watch.Stop();
		meta.Response.ReadElapsed = watch.Elapsed;

		data.MetaData = meta;
		_events.OnResponse(data);
		return data;
	}

	public async Task<T> Request<T>(string url, HttpMethod method, HttpContent? content, bool authRequired, Credentials? creds, CancellationToken token)
		where T : WeebDexResponse
	{
		var meta = new RequestMetaData();
		var watch = Stopwatch.StartNew();
		T? data = null;
		try
		{
			url = WrapUrl(url);

			using var request = await CreateRequest(meta, url, method, content, authRequired, creds);
			using var response = await DoRequest(meta, request, url, token);
			data = await HandleResponse<T>(meta, response, url);

			_events.OnRequestFinished(url, null);
			watch.Stop();
			meta.Elapsed = watch.Elapsed;
			return data;
		}
		catch (Exception ex)
		{
			_events.OnRequestError(url, ex);
			_events.OnRequestFinished(url, ex);
			meta.Response.Exception = ex;
			watch.Stop();
			meta.Elapsed = watch.Elapsed;
			data ??= Activator.CreateInstance<T>();
			data.MetaData = meta;

			if (_api.ThrowOnError)
				throw new WeebDexException(data);

			return data;
		}
	}

	public async Task<TResp> Request<TData, TResp>(string url, HttpMethod method, TData content, bool authRequired, Credentials? creds, CancellationToken token) 
		where TResp : WeebDexResponse
	{
		var str = _json.Serialize(content);
		using var data = new StringContent(str, Encoding.UTF8, "application/json");
		var resp = await Request<TResp>(url, method, data, authRequired, creds, token);
		resp.MetaData.Request.Body = str;
		return resp;
	}
}
