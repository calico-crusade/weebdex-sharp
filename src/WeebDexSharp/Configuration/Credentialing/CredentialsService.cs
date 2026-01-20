namespace WeebDexSharp.Configuration.Credentialing;

/// <inheritdoc cref="ICredentialsService" />
public abstract class CredentialsService : ICredentialsService
{
	/// <summary>
	/// The client secret from the configuration
	/// </summary>
	public abstract string? ClientSecret { get; }

	/// <summary>
	/// The client ID from the configuration
	/// </summary>
	public abstract string? ClientId { get; }

	/// <summary>
	/// The cookie from the configuration
	/// </summary>
	public abstract string? Cookie { get; }

	/// <inheritdoc />
	public virtual Task<Credentials> GetCreds()
	{
		Credentials GetCredsSync()
		{
			if (!string.IsNullOrWhiteSpace(Cookie))
				return Credentials.Cookie(Cookie);

			if (!string.IsNullOrWhiteSpace(ClientSecret) &&
				!string.IsNullOrWhiteSpace(ClientId))
				return Credentials.ApiKey(ClientId, ClientSecret);

			return Credentials.None;
		}

		return Task.FromResult(GetCredsSync());
	}
}
