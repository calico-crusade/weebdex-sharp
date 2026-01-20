namespace WeebDexSharp.Configuration.Credentialing;

/// <summary>
/// Represents a provider that fetches the <see cref="ICredentialsService"/> from the configuration
/// </summary>
/// <param name="_config">The <see cref="IConfiguration"/> object to fetch the variables from</param>
public class ConfigurationCredService(IConfiguration _config) : CredentialsService, ICredentialsService
{
	/// <summary>
	/// Where to fetch the Client Secret from in the config file
	/// </summary>
	public static string ClientSecretPath { get; set; } = "Weebdex:Auth:ClientSecret";

	/// <summary>
	/// Where to fetch the Client ID from in the config file
	/// </summary>
	public static string ClientIdPath { get; set; } = "Weebdex:Auth:ClientId";

	/// <summary>
	/// Where to fetch the Cookie from in the config file
	/// </summary>
	public static string CookiePath { get; set; } = "Weebdex:Auth:Cookie";

	/// <inheritdoc />
	public override string? ClientSecret => _config[ClientSecretPath];

	/// <inheritdoc />
	public override string? ClientId => _config[ClientIdPath];

	/// <inheritdoc />
	public override string? Cookie => _config[CookiePath];
}
