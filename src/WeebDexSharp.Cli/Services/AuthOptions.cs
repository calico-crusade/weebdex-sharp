namespace WeebDexSharp.Cli.Services;

public class AuthOptions
{
	[Option('c', "client-id", HelpText = "The client ID to use for the request. (You can get this from: https://weebdex.org/settings/client)")]
	[Secret]
	public string? ClientId { get; set; }

	[Option('s', "client-secret", HelpText = "The client secret to use for the request. (You can get this from: https://weebdex.org/settings/client)")]
	[Secret]
	public string? ClientSecret { get; set; }

	[Option('k', "cookie", HelpText = "The cookie to use for the request. (You can get this from your browser after logging in to weebdex.org)")]
	[Secret]
	public string? Cookie { get; set; }
}
