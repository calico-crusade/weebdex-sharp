namespace WeebDexSharp.Configuration.Credentialing;

/// <summary>
/// The credentials for authorized requests
/// </summary>
public class Credentials
{
	/// <summary>
	/// The type of credentials being used
	/// </summary>
	public CredentialType Type { get; set; } = CredentialType.None;

	/// <summary>
	/// The value of the credentials
	/// </summary>
	public string? Value { get; set; }

	/// <summary>
	/// Whether or not the credentials are set
	/// </summary>
	public bool IsSet => Type != CredentialType.None && !string.IsNullOrWhiteSpace(Value);

	/// <summary>
	/// No credentials
	/// </summary>
	public static Credentials None => new();

	/// <summary>
	/// Api Key credentials
	/// </summary>
	/// <param name="clientId">The client ID from the API provider</param>
	/// <param name="clientSecret">The client secret from the API provider</param>
	/// <returns>The credentials for the API key</returns>
	public static Credentials ApiKey(string clientId, string clientSecret)
	{
		return new()
		{
			Type = CredentialType.ApiKey,
			Value = $"Bearer {clientId}:{clientSecret}"
		};
	}

	/// <summary>
	/// Cookie credentials
	/// </summary>
	/// <param name="cookie">The cookie string</param>
	/// <returns>The credentials for the cookie</returns>
	public static Credentials Cookie(string cookie)
	{
		return new()
		{
			Type = CredentialType.Cookie,
			Value = cookie
		};
	}
}
