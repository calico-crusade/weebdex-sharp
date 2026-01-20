namespace WeebDexSharp.Configuration.Credentialing;

/// <summary>
/// A service that provides a method for fetching the API credentials for authorized requests
/// </summary>
public interface ICredentialsService
{
	/// <summary>
	/// Get the credentials for authorized requests
	/// </summary>
	/// <returns>The credentials type and the value of the credentials</returns>
	Task<Credentials> GetCreds();
}