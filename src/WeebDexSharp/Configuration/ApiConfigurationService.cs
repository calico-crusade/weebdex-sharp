namespace WeebDexSharp.Configuration;

/// <summary>
/// The configuration options for the WeebDex API services
/// </summary>
public interface IApiConfigurationService
{
	/// <summary>
	/// The URL for the WeebDex API
	/// </summary>
	string ApiUrl { get; }

	/// <summary>
	/// The User-Agent header to send with requests
	/// </summary>
	string UserAgent { get; }

	/// <summary>
	/// Whether or not to throw an exception if the API returns an error
	/// </summary>
	bool ThrowOnError { get; }

	/// <summary>
	/// Whether or not to enable automatic rate limit handling at the API layer
	/// </summary>
	bool RateLimitEnable { get; }

	/// <summary>
	/// The duration to wait before refreshing the rate limits
	/// </summary>
	/// <remarks>Defaults to 1 seconds to observe WD's global rate limit (5 requests per second)</remarks>
	TimeSpan RateLimitRefresh { get; }

	/// <summary>
	/// The duration to wait before refreshing the rate limits (in milliseconds)
	/// </summary>
	/// <remarks>Defaults to 1 seconds to observe WD's global rate limit (5 requests per second)</remarks>
	double RateLimitRefreshMilliseconds { get; }

	/// <summary>
	/// The number of requests that can be done in parallel
	/// </summary>
	/// <remarks>Defaults to 5 to observe WD's global rate limit (5 requests per second)</remarks>
	int RateLimitLeases { get; }

	/// <summary>
	/// Whether or not to queue requests when the rate limit is exceeded (<see langword="true"/>) 
	/// or to fail the request immediately with <see cref="HttpStatusCode.TooManyRequests"/> (<see langword="false"/>)
	/// </summary>
	bool RateLimitQueue { get; }
}

/// <inheritdoc cref="IApiConfigurationService" />
public class ApiConfigurationService : IApiConfigurationService
{
	/// <summary>
	/// The base API URL for the production WD instance
	/// </summary>
	public const string API_ROOT = "https://api.weebdex.org";

	/// <summary>
	/// The base API URL for the developer sandbox WD instance
	/// </summary>
	public const string API_ROOT_DEV = "https://api.weebdex.dev";

	/// <summary>
	/// The user agent to use for all requests
	/// </summary>
	public const string API_USER_AGENT = "weeb-dex-sharp";

	/// <summary>
	/// The default value for whether or not to throw an exception if the API returns an error
	/// </summary>
	public const bool API_THROW_ON_ERROR = false;

	/// <summary>
	/// The default value for whether or not to enable rate limits
	/// </summary>
	public const bool API_RATE_LIMITS_ENABLED = true;

	/// <summary>
	/// The default value for whether to queue requests when the rate limit is exceeded or throw a 429 error
	/// </summary>
	public const bool API_RATE_LIMITS_QUEUE = true;

	/// <summary>
	/// The default value for the number of requests that can be done in parallel
	/// </summary>
	public const int API_RATE_LIMITS_LEASES = 5;

	/// <summary>
	/// The default value for the number of seconds to wait before refreshing the rate limits
	/// </summary>
	public const int API_RATE_LIMITS_REFRESH_SECONDS = 1;

	/// <summary>
	/// Where to fetch the API url from in the config file
	/// </summary>
	public static string ApiPath { get; set; } = "Weebdex:ApiUrl";

	/// <summary>
	/// Where to fetch the User-Agent header from in the config file
	/// </summary>
	public static string UserAgentPath { get; set; } = "Weebdex:UserAgent";

	/// <summary>
	/// Where to fetch the <see cref="ThrowOnError"/> flag from in the config file
	/// </summary>
	public static string ErrorThrownPath { get; set; } = "Weebdex:ThrowOnError";

	/// <summary>
	/// Where to fetch the <see cref="RateLimitEnable"/> from in the config file
	/// </summary>
	public static string RateLimitsEnabledPath { get; set; } = "Weebdex:RateLimits:Enable";

	/// <summary>
	/// Where to fetch the <see cref="RateLimitRefreshMilliseconds"/> from in the config file
	/// </summary>
	public static string RateLimitsRefreshPath { get; set; } = "Weebdex:RateLimits:Refresh";

	/// <summary>
	/// Where to fetch the <see cref="RateLimitLeases"/> from in the config file
	/// </summary>
	public static string RateLimitsLeasesPath { get; set; } = "Weebdex:RateLimits:Leases";

	/// <summary>
	/// Where to fetch the <see cref="RateLimitQueue"/> from in the config file
	/// </summary>
	public static string RateLimitsQueuePath { get; set; } = "Weebdex:RateLimits:Queue";

	/// <inheritdoc />
	public string ApiUrl { get; set; } = API_ROOT;

	/// <inheritdoc />
	public string UserAgent { get; set; } = API_USER_AGENT;

	/// <inheritdoc />
	public bool ThrowOnError { get; set; } = API_THROW_ON_ERROR;

	/// <inheritdoc />
	public bool RateLimitEnable { get; set; } = API_RATE_LIMITS_ENABLED;

	/// <inheritdoc />
	public TimeSpan RateLimitRefresh { get; set; } = TimeSpan.FromSeconds(API_RATE_LIMITS_REFRESH_SECONDS);

	/// <inheritdoc />
	public double RateLimitRefreshMilliseconds
	{
		get => RateLimitRefresh.TotalMilliseconds;
		set => RateLimitRefresh = TimeSpan.FromMilliseconds(value);
	}

	/// <inheritdoc />
	public int RateLimitLeases { get; set; } = API_RATE_LIMITS_LEASES;

	/// <inheritdoc />
	public bool RateLimitQueue { get; set; } = API_RATE_LIMITS_QUEUE;

	/// <summary>
	/// Fetches the API configuration from the provided configuration
	/// </summary>
	/// <param name="config">The configuration to use</param>
	/// <returns>The API configuration</returns>
	public static IApiConfigurationService FromConfiguration(IConfiguration config)
	{
		return new ApiConfigurationService
		{
			ApiUrl = config[ApiPath] ?? API_ROOT,
			UserAgent = config[UserAgentPath] ?? API_USER_AGENT,
			ThrowOnError = (config[ErrorThrownPath] ?? API_THROW_ON_ERROR.ToString()).Equals("true", StringComparison.InvariantCultureIgnoreCase),
			RateLimitEnable = (config[RateLimitsEnabledPath] ?? API_RATE_LIMITS_ENABLED.ToString()).Equals("true", StringComparison.InvariantCultureIgnoreCase),
			RateLimitQueue = (config[RateLimitsQueuePath] ?? API_RATE_LIMITS_QUEUE.ToString()).Equals("true", StringComparison.InvariantCultureIgnoreCase),
			RateLimitLeases = int.TryParse(config[RateLimitsLeasesPath], out var value) ? value : API_RATE_LIMITS_LEASES,
			RateLimitRefreshMilliseconds = double.TryParse(config[RateLimitsRefreshPath], out var msValue) ? msValue : (API_RATE_LIMITS_REFRESH_SECONDS * 1000)
		};
	}

	/// <summary>
	/// Creates a new instance of the API configuration with hardcoded values
	/// </summary>
	/// <param name="apiUrl">The URL for the WeebDex API</param>
	/// <param name="userAgent">The User-Agent header to send with requests</param>
	/// <param name="throwOnError">Whether or not to throw an exception if the API returns an error</param>
	/// <param name="rateLimitsEnabled">Whether or not to enable automatic rate limit handling at the API layer</param>
	/// <param name="rateLimitsLeases">The number of requests that can be done in parallel</param>
	/// <param name="rateLimitsQueue">Whether or not to queue requests when the rate limit is exceeded (<see langword="true"/>) 
	/// or to fail the request immediately with <see cref="HttpStatusCode.TooManyRequests"/> (<see langword="false"/>)</param>
	/// <param name="rateLimitsRefresh">The duration to wait before refreshing the rate limits</param>
	/// <returns>The API configuration</returns>
	public static IApiConfigurationService FromHardCoded(
		string? apiUrl = null, string? userAgent = null, bool? throwOnError = null,
		bool? rateLimitsEnabled = null, bool? rateLimitsQueue = null, 
		int? rateLimitsLeases = null, TimeSpan? rateLimitsRefresh = null)
	{
		return new ApiConfigurationService
		{
			ApiUrl = apiUrl ?? API_ROOT,
			UserAgent = userAgent ?? API_USER_AGENT,
			ThrowOnError = throwOnError ?? API_THROW_ON_ERROR,
			RateLimitEnable = rateLimitsEnabled ?? API_RATE_LIMITS_ENABLED,
			RateLimitQueue = rateLimitsQueue ?? API_RATE_LIMITS_QUEUE,
			RateLimitLeases = rateLimitsLeases ?? API_RATE_LIMITS_LEASES,
			RateLimitRefresh = rateLimitsRefresh ?? TimeSpan.FromSeconds(API_RATE_LIMITS_REFRESH_SECONDS)
		};
	}
}
