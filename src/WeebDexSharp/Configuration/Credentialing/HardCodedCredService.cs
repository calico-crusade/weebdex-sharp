namespace WeebDexSharp.Configuration.Credentialing;

/// <summary>
/// Represents a provider that stores the credentials in-memory
/// </summary>
/// <param name="clientId">The user's client ID (optional)</param>
/// <param name="clientSecret">The user's client secret (optional)</param>
/// <param name="cookie">The user's cookie (optional)</param>
public class HardCodedCredService(
	string? clientId = null,
	string? clientSecret = null,
	string? cookie = null) : CredentialsService, ICredentialsService
{
	/// <inheritdoc />
	public override string? ClientSecret => clientSecret;

	/// <inheritdoc />
	public override string? ClientId => clientId;

	/// <inheritdoc />
	public override string? Cookie => cookie;
}
