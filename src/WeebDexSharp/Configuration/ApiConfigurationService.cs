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
}

/// <summary>
/// The configuration options for the WeebDex API services
/// </summary>
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
	/// Where to fetch the API url from in the config file
	/// </summary>
	public static string ApiPath { get; set; } = "Weebdex:ApiUrl";

	/// <summary>
	/// Where to fetch the User-Agent header from in the config file
	/// </summary>
	public static string UserAgentPath { get; set; } = "Weebdex:UserAgent";

	/// <summary>
	/// Where to fetch the ThrowOnError flag from in the config file
	/// </summary>
	public static string ErrorThrownPath { get; set; } = "Weebdex:ThrowOnError";

	/// <summary>
	/// The URL for the WeebDex API
	/// </summary>
	public string ApiUrl { get; set; } = API_ROOT;

	/// <summary>
	/// The User-Agent header to send with requests
	/// </summary>
	public string UserAgent { get; set; } = API_USER_AGENT;

	/// <summary>
	/// Whether or not to throw an exception if the API returns an error
	/// </summary>
	public bool ThrowOnError { get; set; } = API_THROW_ON_ERROR;

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
			ThrowOnError = config[ErrorThrownPath] == "true"
		};
	}

	/// <summary>
	/// Creates a new instance of the API configuration with hardcoded values
	/// </summary>
	/// <param name="apiUrl">The URL for the WeebDex API</param>
	/// <param name="userAgent">The User-Agent header to send with requests</param>
	/// <param name="throwOnError">Whether or not to throw an exception if the API returns an error</param>
	/// <returns>The API configuration</returns>
	public static IApiConfigurationService FromHardCoded(
		string? apiUrl = null, string? userAgent = null, bool? throwOnError = null)
	{
		return new ApiConfigurationService
		{
			ApiUrl = apiUrl ?? API_ROOT,
			UserAgent = userAgent ?? API_USER_AGENT,
			ThrowOnError = throwOnError ?? API_THROW_ON_ERROR
		};
	}
}
