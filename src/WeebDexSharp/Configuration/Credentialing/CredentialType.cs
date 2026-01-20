namespace WeebDexSharp.Configuration.Credentialing;

/// <summary>
/// Represents the type of credentials the system supports
/// </summary>
public enum CredentialType
{
	/// <summary>
	/// No credentials were supplied
	/// </summary>
	None,
	/// <summary>
	/// Credentials are the client secret and client id via the Authorization header
	/// </summary>
	ApiKey,
	/// <summary>
	/// Credentials are the user's cookie for session authentication
	/// </summary>
	Cookie,
}
