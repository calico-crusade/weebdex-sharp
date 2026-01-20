

namespace WeebDexSharp.Cli.Services;

internal class AuthOptionsCache
{
	public AuthOptions? Auth { get; set; }
}

internal class AuthCredentialsService(
	IConfiguration _config,
	AuthOptionsCache _cache) : CredentialsService
{
	public override string? ClientSecret => _cache.Auth?.ClientSecret.ForceNull() ?? _config[ConfigurationCredService.ClientSecretPath];

	public override string? ClientId => _cache.Auth?.ClientId.ForceNull() ?? _config[ConfigurationCredService.ClientIdPath];

	public override string? Cookie => _cache.Auth?.Cookie.ForceNull() ?? _config[ConfigurationCredService.CookiePath];
}
