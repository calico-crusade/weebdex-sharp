namespace WeebDexSharp.Configuration;

/// <summary>
/// The builder for the <see cref="IApiConfigurationService"/> service
/// </summary>
public class ApiConfigurationBuilder
{
	/// <inheritdoc cref="IApiConfigurationService.ApiUrl" />
	public string? ApiUrl { get; set; }

	/// <inheritdoc cref="IApiConfigurationService.UserAgent" />
	public string? UserAgent { get; set; }

	/// <inheritdoc cref="IApiConfigurationService.ThrowOnError" />
	public bool? ThrowOnError { get; set; }

	/// <inheritdoc cref="IApiConfigurationService.RateLimitEnable" />
	public bool? RateLimitsEnable { get; set; }

	/// <inheritdoc cref="IApiConfigurationService.RateLimitRefresh" />
	public TimeSpan? RateLimitRefresh { get; set; }

	/// <inheritdoc cref="IApiConfigurationService.RateLimitLeases" />
	public int? RateLimitLeases { get; set; }

	/// <inheritdoc cref="IApiConfigurationService.RateLimitQueue" />
	public bool? RateLimitsQueue { get; set; }

	/// <summary>
	/// Uses the given API url
	/// </summary>
	/// <param name="url">The URL to use</param>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithApiUrl(string? url)
	{
		ApiUrl = url;
		return this;
	}

	/// <summary>
	/// Uses the developer API
	/// </summary>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithDevApi()
	{
		return WithApiUrl(ApiConfigurationService.API_ROOT_DEV);
	}

	/// <summary>
	/// Uses the given user-agent
	/// </summary>
	/// <param name="userAgent">The user-agent to use</param>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithUserAgent(string? userAgent)
	{
		UserAgent = userAgent;
		return this;
	}

	/// <summary>
	/// Throws an exception if the API returns an error
	/// </summary>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder ThrowExceptionOnError()
	{
		ThrowOnError = true;
		return this;
	}

	/// <summary>
	/// Doesn't throw an exception if the API returns an error
	/// </summary>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder FailGracefully()
	{
		ThrowOnError = false;
		return this;
	}

	/// <summary>
	/// Whether or not to enable rate limits
	/// </summary>
	/// <param name="enabled">Whether or not to enable automatic rate limit handling at the API layer</param>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithRateLimits(bool enabled = true)
	{
		RateLimitsEnable = enabled;
		return this;
	}

	/// <summary>
	/// Set the number of requests that can be done in parallel
	/// </summary>
	/// <param name="leases">The number of requests that can be done in parallel</param>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithRateLimitsLeases(int leases)
	{
		RateLimitLeases = leases;
		return this;
	}

	/// <summary>
	/// Sets the duration to wait before refreshing the rate limits
	/// </summary>
	/// <param name="duration">The duration to wait before refreshing the rate limits</param>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithRateLimitsRrefresh(TimeSpan duration)
	{
		RateLimitRefresh = duration;
		return this;
	}

	/// <summary>
	/// Sets whether or not to queue requests when the rate limit is exceeded (<see langword="true"/>) 
	/// or to fail the request immediately with <see cref="HttpStatusCode.TooManyRequests"/> (<see langword="false"/>)
	/// </summary>
	/// <param name="queue">Whether or not to queue requests when the rate limit is exceeded (<see langword="true"/>) 
	/// or to fail the request immediately with <see cref="HttpStatusCode.TooManyRequests"/> (<see langword="false"/>)</param>
	/// <returns>The current builder for method chaining</returns>
	public ApiConfigurationBuilder WithRateLimitsQueue(bool queue = true)
	{
		RateLimitsQueue = queue;
		return this;
	}

	internal IApiConfigurationService Build()
	{
		return ApiConfigurationService.FromHardCoded(ApiUrl, UserAgent, ThrowOnError, 
			RateLimitsEnable, RateLimitsQueue, RateLimitLeases, RateLimitRefresh);
	}
}
